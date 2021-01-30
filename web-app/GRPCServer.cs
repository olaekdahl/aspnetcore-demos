using EComm.Web.API.gRPC;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app
{
    public class GRPCServer : EComm.Web.API.gRPC.ECommGrpc.ECommGrpcBase
    {
        public override Task<ProductReply> GetProduct(ProductRequest request, ServerCallContext context)
        {
            int id = request.Id;
            ProductReply reply = new ProductReply();

            return Task.FromResult(new ProductReply { 
                Id = id
                //add other props
            });
        }
    }
}
