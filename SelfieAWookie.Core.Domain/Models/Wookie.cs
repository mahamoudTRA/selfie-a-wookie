namespace SelfieAWookie.Core.Domain.Models
{
    public class Wookie
    {
        #region Properties
        public int Id { get; set; }

        public string? Name { get; set; }

        public IList<Selfie>? Selfies { get; set; }
        #endregion
    }
}