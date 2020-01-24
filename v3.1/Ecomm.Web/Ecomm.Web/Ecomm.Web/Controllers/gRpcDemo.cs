using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomm.Data.Repository;
using EComm.Web.API.gRPC;
using Grpc.Core;

namespace Ecomm.Web.Controllers
{
    public class GRpcDemo : ECommGrpc.ECommGrpcBase
    {
        private IRepository _repo;
        public GRpcDemo(IRepository repo)
        {
            _repo = repo;
        }
 

        public override async Task<ProductReply> GetProduct(ProductRequest request, ServerCallContext context)
        {
            var product = await _repo.FindProductAsync(request.Id);
            
            var reply = new ProductReply
            {
                Id = product.Id,
                Name = product.Name,
                Price = double.Parse(product.UnitPrice.ToString()),
                Supplier = "Acme Inc."
            };
            return reply;
        }
    }
}
