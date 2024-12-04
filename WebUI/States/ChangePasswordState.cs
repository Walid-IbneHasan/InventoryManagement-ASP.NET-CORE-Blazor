namespace WebUI.States
{
    public class ChangePasswordState
    {
        public string? PasswordType = "password";
        public bool PasswordState = true;
        public string DisplayText = "Show";
        public Action? Changed;
        public void ChangePasswordType()
        {
            PasswordState = !PasswordState;
            if (!PasswordState)
            {
                PasswordType = "text";
                DisplayText = "Hide";
            }
            else
            {
                PasswordType = "password";
                DisplayText = "Show";
            }
            Changed?.Invoke();
        }
    }
}
