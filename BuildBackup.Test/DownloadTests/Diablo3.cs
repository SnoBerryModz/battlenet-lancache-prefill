﻿using System.Linq;
using BuildBackup.DebugUtil.Models;
using ByteSizeLib;
using Konsole;
using NUnit.Framework;

namespace BuildBackup.Test.DownloadTests
{
    public class Diablo3
    {
        private ComparisonResult _results;

        [OneTimeSetUp]
        public void Setup()
        {
            // Run the download process only once
            _results = Program.ProcessProduct(TactProducts.Diablo3, new MockConsole(120, 50), true);
        }

        [Test]
        public void Misses()
        {
            Assert.LessOrEqual(0, _results.MissCount);
        }

        [Test]
        public void MissedBandwidth()
        {
            var missedBandwidth = ByteSize.FromBytes(_results.Misses.Sum(e => e.TotalBytes));
            Assert.AreEqual(missedBandwidth.Bytes, 0);
        }

        [Test]
        public void WastedBandwidth()
        {
            //TODO improve this
            var expected = ByteSize.FromMegaBytes(1600);

            var wastedBandwidth = ByteSize.FromBytes(_results.UnnecessaryRequests.Sum(e => e.TotalBytes));
            Assert.Less(wastedBandwidth.Bytes, expected.Bytes);
        }
    }
}
