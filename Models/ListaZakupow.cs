namespace ListaZakupowMVC.Models
{
    public class ListaZakupow
    {
        private bool _isset;

        public required int Id { get; set; }

        public string? Description { get; set; }

        public bool  IsSet 
        {
            get 
            { 
                return _isset;
            }
            set 
            { 
                _isset = value;
            } 
        }
    }
}
