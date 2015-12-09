﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Windows.Data.Xml.Dom;


namespace DataLayer
{
    public class DAO
    {
        public static async Task<XmlDocument> LoadDatabase()
        {
            var loadSettings = new XmlLoadSettings
            {
                ProhibitDtd = false,
                ResolveExternals = true
            };

            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Database");
            var file = await folder.GetFileAsync("database.xml");

            return await Windows.Data.Xml.Dom.XmlDocument.LoadFromFileAsync(file, loadSettings);

        }

        public async Task<XmlNodeList> GetNodeList(string xpath)
        {
            var doc = await LoadDatabase();
            var nodeList = doc.SelectNodes(xpath);
            return nodeList;
        }
        public async Task<IXmlNode> GetSingleNode(string xpath)
        {
            var doc = await LoadDatabase();
            var node = doc.SelectSingleNode(xpath);
            return node;
        }
    }
}
