using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace Divuvina.Models.Public
{
    public class RMessage
    {
        public bool Result { get; set; }
        public string MessageId { get; set; }
        public string ErrorMessage { get; set; }
        public string SystemMessage { get; set; }
    }

    public class ErrorMessages
    {
        public static string RootNote = "RMessage";
        public static string Child_VNErrorType = "VNErrorType";
        public static string Child_ErrorMessages = "ErrorMessages";
        public static string SubChild_VNErrorType_DataAction = "DataAction";
        public static string SubChild_VNErrorType_AssignValueForControl = "AssignValueForControl";
        public static string SubChild_VNErrorType_InvalidDataOfControl = "InvalidDataOfControl";
        public static string SubChild_VNErrorType_WindowSystem = "WindowSystem";
        public static string SubChild_VNErrorType_WorkOutDatabase = "WorkOutDatabase";
        public static string SubChild_VNErrorType_Infomation = "Infomation";
        public static string SubChild_VNErrorType_Permission = "Permission";
        public static string SubChild_ErrorMessages_Controls = "Controls";
        public static string SubChild_ErrorMessages_Permission = "Permissions";
        public static string SubChild_ErrorMessages_DataActions = "DataActions";
        public static string SubChild_Controls_InitDefaultValue = "InitDefaultValue";
        public static string SubChild_Controls_AssignValue = "AssignValue";
        public static string SubChild_Controls_GetValue = "GetValue";
        public static string SubChild_Controls_ShowDataToGrid = "ShowDataToGrid";
        public static string SubChild_Permission_InvalidPermission = "InvalidPermission";
        public static string SubChild_DataActions_GetData = "GetData";
        public static string SubChild_DataActions_InsertData = "InsertData";
        public static string SubChild_DataActions_DeleteData = "DeleteData";
        public static string SubChild_DataActions_UpdateData = "UpdateData";
        public static string SubChild_DataActions_DatabaseActions = "DatabaseActions";
        public static string SubChild_DataActions_ShowData = "ShowData";
        public static string SubChild_DataActions_ConvertData = "ConvertData";
        public static string SubChild_DataActions_InvalidData = "InvalidData";
        public static string SubChild_DataActions_ConnectDatabase = "ConnectDatabase";

        private static string _FileErrorMessagesXMLPath = @"Data/ErrorMessages.xml";

        public static string TitleMessage(string node)
        {
            return ReadMessage(Child_VNErrorType, node);
        }
        public static string ReadMessage(string parentNode, string childNode)
        {
            XmlDocument xmlDoc = new XmlDocument();

            string fileErrorMessagesXML = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _FileErrorMessagesXMLPath);
            xmlDoc.Load(fileErrorMessagesXML);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes(parentNode);
            if (nodeList != null && nodeList.Count == 1) return nodeList[0].SelectSingleNode(childNode).InnerText;
            return string.Empty;
        }
        public static string ReadMessage(string node)
        {
            XmlDocument xmlDoc = new XmlDocument();

            string fileErrorMessagesXML = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _FileErrorMessagesXMLPath);
            xmlDoc.Load(fileErrorMessagesXML);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(node);

            if (nodeList != null && nodeList.Count == 1) return nodeList[0].InnerText;
            return string.Empty;
        }

    }//EndClass
}//EndNamespace
