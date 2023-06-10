namespace Fiorello_backend.Areas.Admin.ViewModels.Product
{
    public class ProductEditVM
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int DiscountId { get; set; }
        public List<IFormFile> Images { get; set; }
    
        public string NewName { get; set; }
      
        public string NewDescription { get; set; }
     
        public decimal NewPrice { get; set; }
       
      
        public IFormFile NewImage { get; set; }
    }
}
