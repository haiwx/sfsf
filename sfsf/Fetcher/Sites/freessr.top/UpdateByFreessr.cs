﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShadowsocksFreeServerFetcher
{
    [ServerInfoFetcher("freessr.top")]
    class UpdateByFreessr : ServerInfoFetcher
    {

        static Regex parser = new Regex(
            @"(?=服务器地址[\s:：]\s*(?<host>.*)\s*)" +
            @"(?=.(?:(?!服务器地址)[\s\S])*?端口[\s:：]\s*(?<port>\d*)\s*)" +
            @"(?=.(?:(?!服务器地址)[\s\S])*?密码[\s:：]\s*(?<password>.*)\s*)" +
            @"(?=.(?:(?!服务器地址)[\s\S])*?加密方式[\s:：]\s*(?<method>.*)\s*)" +
            @"(?=.(?:(?!服务器地址)[\s\S])*?状态[\s:：]\s*正常\s*)" +
        "");

        override protected IEnumerable<ServerInfo> FetchServers()
        {
            HtmlDocument webpageDocument = new HtmlWeb().Load("http://freessr.top/");
            HtmlNode contentNode = webpageDocument.DocumentNode.SelectSingleNode("//div[@class=\"row\"]");
            return ServerInfoParser.ReadFromTextMulti(contentNode.InnerText, parser);
        }

    }
}
