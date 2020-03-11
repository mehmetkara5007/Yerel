using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using System.Configuration;
using System.Web.Mvc;
using Yerel.ClipTwo.Infrastructure;
using Yerel.ClipTwo.Models;

namespace Yerel.ClipTwo.Controllers
{
    public class BucketController : BaseController
    {
        #region Variables
        AmazonS3Client client;
        const string bucketName = "secondappname";
        const string keyValue = "test.txt";
        public BasicAWSCredentials credentials = new BasicAWSCredentials(
      ConfigurationManager.AppSettings["accessId"],
      ConfigurationManager.AppSettings["secretKey"]);
        #endregion
        // GET: Bucket
        public ActionResult List()
        {
            var operation = new S3BucketOprations();
            var model = new BucketViewModel
            {
                Buckets = operation.ListBucket()
            };
            return View(model);
        }
        public ActionResult Create()
        {
            client = new AmazonS3Client(credentials,
              Amazon.RegionEndpoint.EUWest1);

            if (AmazonS3Util.DoesS3BucketExistV2(client, bucketName))
            {
                SuccessNotification("The bucket created succesfully");
            }
            else
            {
                var bucketRequest = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true,
                };
                var bucketResponse = client.PutBucket(bucketRequest);
                if (bucketResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    SuccessNotification("The bucket created succesfully");
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Version()
        {
            client = new AmazonS3Client(credentials,
              Amazon.RegionEndpoint.EUWest1);

            PutBucketVersioningRequest request = new PutBucketVersioningRequest
            {
                BucketName = bucketName,
                VersioningConfig = new S3BucketVersioningConfig
                {
                    EnableMfaDelete = false,
                    Status = VersionStatus.Enabled
                }
            };

            var response = client.PutBucketVersioning(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                SuccessNotification("The bucket versioned");
            }
            return RedirectToAction("List");
        }

        public ActionResult Accelarate()
        {
            client = new AmazonS3Client(credentials,
              Amazon.RegionEndpoint.EUWest1);
            PutBucketAccelerateConfigurationRequest request = new PutBucketAccelerateConfigurationRequest
            {
                BucketName = bucketName,
                AccelerateConfiguration = new AccelerateConfiguration
                {
                    Status = BucketAccelerateStatus.Enabled
                }
            };

            var response = client.PutBucketAccelerateConfiguration(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                SuccessNotification("The bucket accelarated");
            }
            return RedirectToAction("List");
        }
    }
}