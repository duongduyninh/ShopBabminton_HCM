namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class GetInfoInCartDetailResponse
    {
       public bool Status { get; set; }
        public string Message { get; set; }
        public List<CartDetailInfo> cartDetail {  get; set; }
    }
}
