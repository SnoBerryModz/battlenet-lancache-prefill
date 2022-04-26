﻿using System.Linq;
using System.Threading.Tasks;
using BattleNetPrefill.Utils.Debug.Models;
using ByteSizeLib;
using NUnit.Framework;
using Spectre.Console.Testing;

namespace BattleNetPrefill.Test.DownloadTests.Blizzard
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class WorldOfWarcraft
    {
        private ComparisonResult _results;

        [OneTimeSetUp]
        public async Task Setup()
        {
            // Run the download process only once
            _results = await TactProductHandler.ProcessProductAsync(TactProduct.WorldOfWarcraft, new TestConsole(), useDebugMode: true, showDebugStats: true);
        }

        [Test]
        public void Misses()
        {
            //TODO improve
            var expected = 5;
            Assert.LessOrEqual(_results.MissCount, expected);
        }

        [Test]
        public void MissedBandwidth()
        {
            //TODO improve this
            var expected = ByteSize.FromMegaBytes(1).Bytes;

            var missedBandwidthBytes = ByteSize.FromBytes(_results.Misses.Sum(e => e.TotalBytes)).Bytes;

            Assert.LessOrEqual(missedBandwidthBytes, expected);
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
