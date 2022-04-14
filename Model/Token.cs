namespace UsuarioAPI.Model
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;       
        }
        public string Value { get; }
    }
}
