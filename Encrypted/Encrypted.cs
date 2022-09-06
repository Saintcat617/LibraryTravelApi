namespace LibraryTravelApi.Encrypted
{
    public class Encrypted
    {
        public string Base64Encode(string p_0)
        {
            var p_0_Bytes = System.Text.Encoding.UTF8.GetBytes(p_0);
            return System.Convert.ToBase64String(p_0_Bytes);
        }
        public string Base64Decode(string p_0)
        {
            var p_0_dBytes = System.Convert.FromBase64String(p_0);
            return System.Text.Encoding.UTF8.GetString(p_0_dBytes);
        }
    }
}
