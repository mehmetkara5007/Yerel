using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Yerel.ClipTwo.Infrastructure
{
    public class S3BucketOprations : IDisposable
    {
        #region Variables
        AmazonS3Client client;
        const string bucketName = "visma-aws-yerel";
        const string keyValue = "test.txt";
        public BasicAWSCredentials credentials = new BasicAWSCredentials(
      ConfigurationManager.AppSettings["accessId"],
      ConfigurationManager.AppSettings["secretKey"]);
        #endregion

        public S3BucketOprations()
        {
            client = new AmazonS3Client(credentials,
                Amazon.RegionEndpoint.EUWest1);
        }

        public void CreateBucket()
        {
            if (AmazonS3Util.DoesS3BucketExistV2(client, "myappname"))
            {
                Console.WriteLine("The bucket created succesfullyt ");
            }
            else
            {
                var bucketRequest = new PutBucketRequest
                {
                    BucketName = "myappname",
                    UseClientRegion = true,
                };
                var bucketResponse = client.PutBucket(bucketRequest);
                if (bucketResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("The bucket created succesfullyt ");
                }
            }
        }

        public void UploadFile()
        {
            //Dosya yükleme
            //var transferUtility = new TransferUtility(client);
            //transferUtility.Upload(
            //    AppDomain.CurrentDomain.BaseDirectory + "\\test.txt", bucketName);
            //Console.WriteLine("başarılı, yüklendi dosya");

            //klasör upload etme
            //var transferUtility = new TransferUtility(client);
            //transferUtility.UploadDirectory(
            //    AppDomain.CurrentDomain.BaseDirectory + "\\example", bucketName);
            //Console.WriteLine("başarılı, yüklendi klasör");
            //Console.ReadLine();

            //İzin isteme gönderilen dosya için
            var transferUtility = new TransferUtility(client);
            var transferForRequest = new TransferUtilityUploadRequest
            {
                FilePath =
                AppDomain.CurrentDomain.BaseDirectory + "\\test.txt",
                CannedACL = S3CannedACL.PublicRead,
                BucketName = bucketName

            };
            transferUtility.Upload(transferForRequest);
            Console.WriteLine("başarılı, ");
            Console.ReadLine();
        }

        public async Task DownloadFileAsync()
        {
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = "text.txt"
            };

            using (GetObjectResponse response = await client.GetObjectAsync(request))
            {
                using (Stream responseStream = response.ResponseStream)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string content = reader.ReadToEnd();
                        var contentType = response.Headers["Content-Type"];

                        Console.WriteLine("File Content: ");
                        Console.WriteLine(content);

                        Console.WriteLine("File Content-Type: ");
                        Console.WriteLine(contentType);

                        Console.ReadLine();
                    }
                }
            }
        }

        //Süreli dosya paylaşımı yapma 
        public void PresSignedUrl()
        {
            try
            {
                GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = "test.txt",
                    Expires = DateTime.Now.AddMinutes(5),
                    Verb = HttpVerb.GET
                };

                var result = client.GetPreSignedURL(request);
                Console.WriteLine("Signed Url: ");
                Console.WriteLine(result);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Amazon Error:{0} ", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Normal Error:{0} ", e.Message);
            }
            Console.ReadLine();
        }

        //bucketa gelen dosyaları ayırt etme
        //olayı kim koydu bu dosyayı
        public void GetObjectTagging()
        {
            GetObjectTaggingRequest request = new GetObjectTaggingRequest
            {
                BucketName = bucketName,
                Key = "test.txt",
            };

            GetObjectTaggingResponse response = client.GetObjectTagging(request);
            if (response.Tagging.Count == 0)
            {
                Console.WriteLine("tags are not found");
            }

            foreach (var tag in response.Tagging)
            {
                Console.WriteLine($"Key:{tag.Key}, Values: {tag.Value}");
            }
            Console.ReadLine();
        }

        public void UpdateObjectTagging()
        {
            Tagging tags = new Tagging();
            tags.TagSet = new List<Tag>
            {
            new Tag{ Key="TagKey1", Value = "TagValue1"},
            new Tag{ Key="TagKey2", Value = "TagValue2"},
            };

            PutObjectTaggingRequest request = new PutObjectTaggingRequest
            {
                BucketName = bucketName,
                Key = "test.txt",
                Tagging = tags
            };

            PutObjectTaggingResponse response = client.PutObjectTagging(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("basarlı, değiştirme.");
            }
            Console.ReadLine();
            GetObjectTagging();
        }

        public void UpdateObjectACL()
        {
            PutACLRequest request = new PutACLRequest
            {
                BucketName = bucketName,
                Key = keyValue,
                CannedACL = S3CannedACL.PublicRead
            };

            var response = client.PutACL(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("basarlı, okuma izni.");
            }
            Console.ReadLine();
        }

        //Versiyonlama yap
        public void BucketVersiyon()
        {
            PutBucketVersioningRequest request = new PutBucketVersioningRequest
            {
                BucketName = bucketName,
                VersioningConfig = new S3BucketVersioningConfig
                {
                    EnableMfaDelete = false,
                    Status = VersionStatus.Enabled
                }
            };

            //var response = client.PutBucketVersioning(request);
            //if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    Console.WriteLine("Versiyoning is succesfull.");
            //}
            //Console.ReadLine();
        }

        public void BucketAccelarate()
        {
            PutBucketAccelerateConfigurationRequest request = new PutBucketAccelerateConfigurationRequest
            {
                BucketName = bucketName,
                AccelerateConfiguration = new AccelerateConfiguration
                {
                    Status = BucketAccelerateStatus.Enabled
                }
            };

            //var response = client.PutBucketAccelerateConfiguration(request);
            //if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    Console.WriteLine("Accelarate is succesfull.");
            //}
            //Console.ReadLine();
        }

        public List<string> ListBucket()
        {
            var results = new List<string>();
            using (AmazonS3Client client = new AmazonS3Client
                (credentials, Amazon.RegionEndpoint.EUWest1))
            {
                foreach (var item in client.ListBuckets().Buckets)
                {
                    results.Add(item.BucketName);
                }
            }
            return results;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}