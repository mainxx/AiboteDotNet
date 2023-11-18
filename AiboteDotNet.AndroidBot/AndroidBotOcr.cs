using AiboteDotNet.AndroidBot.Api;
using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IOcr
    {
        public Task<PositionConnent> FindWords(string words, Region region, int scale)
        {
            return FindWords(words, region, ThresholdTypes.THRESH_BINARY, 0, scale);
        }
        public async Task<PositionConnent> FindWords(string words, Region region, ThresholdTypes thresholdType, int thresh, int scale)
        {
            var result = await GetWords(region, thresholdType, thresh, scale);
            var find = result.FirstOrDefault(x => x.Connent == words);
            return find;
        }

        public async Task<PositionConnent> FindWords(string words)
        {
            var result = await GetWords();
            var find = result.FirstOrDefault(x => x.Connent == words);
            return find;
        }
        public async Task<PositionConnent> FindContainsWords(string words)
        {
            var result = await GetWords();
            var find = result.FirstOrDefault(x => x.Connent.Contains(words));
            return find;
        }

        public Task<List<PositionConnent>> GetWords(Region region, int scale)
        {
            return GetWords(region, ThresholdTypes.THRESH_BINARY, 0, scale);
        }
        public Task<List<PositionConnent>> GetWords(Region region, ThresholdTypes thresholdType, int thresh, int scale)
        {
            return _AndroidBotCore.Ocr(region.Left, region.Right, region.Right, region.Bottom, thresholdType.GetHashCode(), thresh, scale);
        }
        public Task<List<PositionConnent>> GetWords()
        {
            return _AndroidBotCore.Ocr(0, 0, 0, 0, 0, 0, 1);
        }

        public Task<bool> InitOcr(string ocrServerIp, int ocrServerPort = 9527)
        {
            return _AndroidBotCore.InitOcr(ocrServerIp, ocrServerPort);
        }


    }
}
