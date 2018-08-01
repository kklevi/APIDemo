using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace APIDemo
{
    class Program
    {
        public static string  username = "bgare@foodchainid.com";
        public static string  password = "FfIaID!$8013";


        static void Main(string[] args)
        {
            
            XmlNode result = GetNonGmoClientData(7);

            System.Console.WriteLine(result.InnerText);


            System.Console.ReadLine();
        }

        public static XmlNode GetNonGmoClientData(int userid)
        {
            NGPDemo.WebServiceProviderSoapClient service = new NGPDemo.WebServiceProviderSoapClient();
            NGPDemo.WebServiceProviderSOAPHeader header = new NGPDemo.WebServiceProviderSOAPHeader();

            header.Username = username;
            header.Password = password;

            XmlDocument doc = new XmlDocument();
            XmlNode id = doc.CreateNode("element", "ngp_clientid", "");
            id.InnerText = Convert.ToString(userid);

            Console.WriteLine(id.OuterXml);

            string name = "GetNonGmoClientData";
            XmlNode serviceResult = service.GetData(header, name, id);
            service.Close();

            return serviceResult;
        }


        //This will timeout
        public static XmlNode GetCertificate()
        {
            NGPDemo.WebServiceProviderSoapClient service = new NGPDemo.WebServiceProviderSoapClient();
            NGPDemo.WebServiceProviderSOAPHeader header = new NGPDemo.WebServiceProviderSOAPHeader();
            
            header.Username = username;
            header.Password = password;


            XmlDocument doc = new XmlDocument();

            string name = "GetNonGmoCertificates";
            XmlNode serviceResult = service.GetData(header, name, null);

            return serviceResult;
        }

        public static XmlNode GetDataParameterSchema(string functionName)
        {
            NGPDemo.WebServiceProviderSoapClient service = new NGPDemo.WebServiceProviderSoapClient();
            NGPDemo.WebServiceProviderSOAPHeader header = new NGPDemo.WebServiceProviderSOAPHeader();

            header.Username = username;
            header.Password = password;

            XmlNode serviceResult = service.GetDataParameterSchema(header, functionName);
            return serviceResult;
        }

    }
}
