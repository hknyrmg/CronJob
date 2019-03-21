using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CronJob
{
    public class XmlReader
    {
        //public void XmlRead(string Url)
        //{

        //    String URLString = Url;
        //    XmlTextReader reader = new XmlTextReader(URLString);

        //    while (reader.Read())
        //    {
        //        switch (reader.NodeType)
        //        {
        //            case XmlNodeType.Element: // The node is an element.
        //                Console.Write("<" + reader.Name);

        //                while (reader.MoveToNextAttribute()) // Read the attributes.
        //                    Console.Write(" " + reader.Name + "='" + reader.Value + "'");
        //                Console.Write(">");
        //                Console.WriteLine(">");
        //                break;
        //            case XmlNodeType.Text: //Display the text in each element.
        //                Console.WriteLine(reader.Value);
        //                break;
        //            case XmlNodeType.EndElement: //Display the end of the element.
        //                Console.Write("</" + reader.Name);
        //                Console.WriteLine(">");
        //                break;
        //        }
        //    }
        //}
        public  T GetXmlRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string xmlOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        xmlOutput = sr.ReadToEnd();

                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));

                    var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

                    if (xmlResult != null)
                        return xmlResult;
                    else
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                // Log error here.
                return default(T);
            }
        }
    }
}

