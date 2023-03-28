namespace Models
{
    public class Allergy
    {
        public int id { get; set; }
        public int? VisitId { get; set; }

        public string? AllergyName { get; set; }

        public string? Notes { get; set; }
        public override string ToString()
        {
            return $"{id} {VisitId} {AllergyName} {Notes} ";
        }
    }
}