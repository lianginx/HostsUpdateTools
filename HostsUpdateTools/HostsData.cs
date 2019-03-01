using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HostsUpdateTools
{
    static class Hosts
    {
        public static async Task<string> DownloadHostsStringAsync(string hostsUri)
        {
            WebClient client = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            return await client.DownloadStringTaskAsync(hostsUri);
        }

        public static HostsData GetHostsData(string hostsString, string regexString)
        {
            Regex regex = new Regex(regexString);
            string time = regex.Match(hostsString).Groups["time"].Value;
            DateTime.TryParse(time, out DateTime dateTime);
            return new HostsData()
            {
                HostsString = hostsString,
                HostsTime =  dateTime
            };
        }
    }

    struct HostsData
    {
        public string HostsString { get; set; }
        public DateTime HostsTime { get; set; }

        /// <summary>
        /// 对比传入实例，并返回一个指示是早于、等于还是晚于传入实例的整数。
        /// </summary>
        /// <param name="other">传入的实例</param>
        /// <returns></returns>
        public int Equals(HostsData other)
        {
            return DateTime.Compare(HostsTime, other.HostsTime);
        }

        public new string ToString() => HostsString;
    }
}
