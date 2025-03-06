namespace ButtonGrid.Models
{
    public class ButtonModel
    {
        public int Id { get; set; }
        public int buttonState { get; set; }
        public string buttonImage { get; set; }

        public ButtonModel(int Id, int buttonState, string buttonImage) 
        {
            this.Id = Id;
            this.buttonState = buttonState;
            this.buttonImage = buttonImage;
        }

        public ButtonModel() { }
    }

    public class ButtonViewModel
    {
        public List<ButtonModel> Buttons { get; set; }
        public bool Complete { get; set; }

        public int Goal { get; set; }
    }
}
