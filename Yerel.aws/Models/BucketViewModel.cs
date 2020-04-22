using Amazon.S3;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yerel.Entities;

namespace Yerel.aws.Models
{
    public class BucketViewModel
    {
        public List<string> Buckets { get; set; }
     
    }
}