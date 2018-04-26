using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalInstruments.Infrastructure;
using MedicalInstruments.Model;
using Newtonsoft.Json;

namespace MedicalInstrumentsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var publicKey = @"
                            MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC7PyjMEuniN6BPn8oqzIZ6AO1N
                            jSTO9R3adCCIwKfKIEoWXXM+tHDpktdPKSaAsWJPTNAGvEvtxOfzXib/EMXKqD0e
                            Uy5MatfpRjRdf1hJVimmfrb09Qx2j7CsKLy7nD23m4xubdYBwvkjMwt/L3JxB5D6
                            qryW1wei/j1c+/OCxQIDAQAB
                            ";


            var privateKey = @"MIICXQIBAAKBgQC7PyjMEuniN6BPn8oqzIZ6AO1NjSTO9R3adCCIwKfKIEoWXXM+
tHDpktdPKSaAsWJPTNAGvEvtxOfzXib/EMXKqD0eUy5MatfpRjRdf1hJVimmfrb0
9Qx2j7CsKLy7nD23m4xubdYBwvkjMwt/L3JxB5D6qryW1wei/j1c+/OCxQIDAQAB
AoGAT7vGYJgRNf4f6qgNS4pKHTu10RcwPFyOOM7IZ9M5380+HyXuBB6MEjowKwpH
1fcy+LepwaR+5KG7b5uBGY4H2ticMtdysBd9gLwnY4Eh4j7LCWE54HvELpeWXkWp
FQdb/NQhcqMAGwYsTnRPdBqkrUmJBTYqEGkIlqCQ5vUJOCECQQDhe0KGmbq1RWp6
TDvgpA2dUmlt2fdP8oNW8O7MvbDaQRduoZnVRTPYCDKfzFqpNXL1hAYgth1N0vzD
nv3VoLcpAkEA1JcY+rLv5js1g5Luv8LaI5/3uOg0CW7fmh/LfGuz8k/OxASN+cAO
UjPHrxtc5xn1zat4/bnV5GEdlOp/DhquPQJBAIV2Fsdi4M+AueiPjPWHRQO0jvDV
jfwFOFZSn5YSRUa6NmtmPY6tumUJXSWWqKb1GwlVTuc3xBqXYsNLLUWwLhkCQQDJ
UJCiD0LohhdGEqUuSKnj5H9kxddJO4pZXFSI7UEJbJQDwcBkyn+FTm2BH+tZGZdQ
fVnlA89OJr0poOpSg+eNAkAKY85SR9KASaTiDBoPpJ8N805XEhd0Kq+ghzSThxL3
fVtKUQLiCh7Yd8oMd/G5S3xWJHUXSioATT8uPRH2bOb/";


            var launchInfo = new LaunchInfo
            {
                ComputerName = MachineInfo.Instance.GetComputerName(),
                CPUSerialNumber = MachineInfo.Instance.GetCPUSerialNumber(),
                MACAddress = MachineInfo.Instance.GetMacAddress(),
                Name = "测试",
                ProductKey = "G5S3xWJHUXSioATT8uPRH2bOb",
                SystemType = MachineInfo.Instance.GetSystemType(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            var serializedText = JsonConvert.SerializeObject(launchInfo);


            var privateCryto = new RSACryptoService(privateKey);
            var publickCryto = new RSACryptoService(null, publicKey);

            var encryptedText = publickCryto.Encrypt(serializedText);

            var decryptedText = privateCryto.Decrypt(encryptedText);

            Assert.IsTrue(serializedText == decryptedText);


        }
    }
}
