namespace XmlImport.Models
{
    public class Master
    {
        public int Id { get; set; }
        public string CIK { get; set; }
        public string CompanyName { get; set; }
        public string FormType { get; set; }//через ковычки
        public string DateFiled { get; set; }
        public string FileName { get; set; }//через ковычки

        public Master()  //пустой конструктор
        {
        }
        public Master(string cik, string companyName, string formType, string dateFiled, string fileName)
        {
            CIK = cik;
            CompanyName = companyName;
            FormType = formType;
            DateFiled = dateFiled;
            FileName = fileName;
        }
    }
}
