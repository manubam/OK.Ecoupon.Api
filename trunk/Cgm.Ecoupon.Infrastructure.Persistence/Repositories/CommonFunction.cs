using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace Cgm.Ecoupon.Infrastructure.Persistence.Repositories
{
    public class CommonFunction
    {
        public async Task<string> CheckOperators(string mobileNo)
        {
            string mobileOperator = "Invalid Mobile";
            if (mobileNo.StartsWith("0095"))
            {
                string newNumber = mobileNo.Remove(1, 3);
                mobileNo = newNumber;
            }
            if (mobileNo.Length == 11)
            {
                if (mobileNo.StartsWith("0997") || mobileNo.StartsWith("0996") || mobileNo.StartsWith("0995") || mobileNo.StartsWith("0998") || mobileNo.StartsWith("0994"))
                {
                    mobileOperator = "Ooredoo";
                    return mobileOperator;
                }
                else if (mobileNo.StartsWith("0974") || mobileNo.StartsWith("0975") || mobileNo.StartsWith("0976") || mobileNo.StartsWith("0977") || mobileNo.StartsWith("0978") || mobileNo.StartsWith("0979"))
                {
                    mobileOperator = "Telenor";
                    return mobileOperator;
                }
                else if (mobileNo.StartsWith("0969") || mobileNo.StartsWith("0968") || mobileNo.StartsWith("0967") || mobileNo.StartsWith("0966") ||
                         mobileNo.StartsWith("0965"))
                {
                    mobileOperator = "Mytel";
                    return mobileOperator;
                }
                else if (mobileNo.StartsWith("098") || mobileNo.StartsWith("0925") || mobileNo.StartsWith("0926") || mobileNo.StartsWith("0940") || mobileNo.StartsWith("0942") || mobileNo.StartsWith("0944") || mobileNo.StartsWith("0945") || mobileNo.StartsWith("0946"))
                {
                    mobileOperator = "Mpt";
                    return mobileOperator;
                }
                else if (mobileNo.StartsWith("0934") || mobileNo.StartsWith("0935") || mobileNo.StartsWith("0936") || mobileNo.StartsWith("093"))
                {
                    mobileOperator = "Mectel";
                    return mobileOperator;
                }
            }
            else if (mobileNo.Length == 10)
            {
                if (mobileNo.StartsWith("0941") || mobileNo.StartsWith("0943") || mobileNo.StartsWith("0947") || mobileNo.StartsWith("0949") || mobileNo.StartsWith("0973") || mobileNo.StartsWith("0991") || mobileNo.StartsWith("098"))
                {
                    mobileOperator = "Mpt";
                    return mobileOperator;
                }
                else if (mobileNo.StartsWith("093"))
                {
                    mobileOperator = "Mectel";
                    return mobileOperator;
                }
            }
            else if (mobileNo.Length == 9)
            {
                if (mobileNo.StartsWith("0920") || mobileNo.StartsWith("0921") || mobileNo.StartsWith("0922") || mobileNo.StartsWith("0923") || mobileNo.StartsWith("0924") || mobileNo.StartsWith("095") || mobileNo.StartsWith("0964") || mobileNo.StartsWith("0966") || mobileNo.StartsWith("098"))
                {
                    mobileOperator = "Mpt";
                    return mobileOperator;
                }
                else if (mobileNo.StartsWith("093"))
                {
                    mobileOperator = "Mectel";
                    return mobileOperator;
                }
            }
            else
            {
                if (mobileNo.StartsWith("0960") || mobileNo.StartsWith("0961") || mobileNo.StartsWith("0962") || mobileNo.StartsWith("0963") || mobileNo.StartsWith("0971") || mobileNo.StartsWith("0972") || mobileNo.StartsWith("0992")
                    || mobileNo.StartsWith("0993") || mobileNo.StartsWith("0900") || mobileNo.StartsWith("0911"))
                {
                    mobileOperator = "Invalid Mobile";
                    return mobileOperator;
                }
            }

            return mobileOperator;
        }


        public string OKdollarRegisterNumber(string MobileNumber, bool okAccNumber)
        {
            string data = "";
            string code = "0";
            //string url = "http://www.okdollar.net/WebServiceIpay/services/request;requesttype=AUTH;agentcode=" + MobileNumber + ";vendorcode=IPAY;clienttype=GPRS";
            string url = "http://120.50.43.150:8090/WebServiceIpay/services/request;requesttype=AUTH;agentcode=" + MobileNumber + ";vendorcode=IPAY;clienttype=GPRS";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            var content = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();

                        var lresponsexml = content;



                        var xdocLogin = new XmlDocument();
                        xdocLogin.LoadXml(lresponsexml);
                        data = lresponsexml;
                        var responselogin = xdocLogin.SelectSingleNode("/estel/response");

                        if (responselogin != null)
                        {
                            var xmlNodelogin = responselogin.SelectSingleNode("resultcode");
                            var xmlresultdescription = responselogin.SelectSingleNode("resultdescription").InnerText;
                            if (xmlNodelogin != null)
                            {
                                code = xmlNodelogin.InnerText;



                            }
                        }
                    }
                }
            }

            return code;
        }


    }
}
