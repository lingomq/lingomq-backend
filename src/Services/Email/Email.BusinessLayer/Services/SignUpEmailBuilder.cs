﻿namespace Email.BusinessLayer.Services
{
    public class SignUpEmailBuilder : SignInEmailBuilder
    {
        public override void SetHeader() =>
            EmailTemplate!.Header = "Подтверждение регистрации";

        public override void SetText() =>
            EmailTemplate!.Text = $"Спасибо за регистрацию на нашем сайте!" +
            $"Мы должны подтвердить ваш аккаунт, поэтому вам необходимо нажать " +
            $"на кнопку ниже, вы будете перенаправлены на сайт для подтверждения аккаунта." +
            $"<br> Если это были не вы, то просто игнорируйте данное сообщение";
        public override void SetButton() =>
            EmailTemplate!.ButtonName = "Подтвердить";
    }
}
