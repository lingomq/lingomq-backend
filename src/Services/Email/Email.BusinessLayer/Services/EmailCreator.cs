﻿using Email.BusinessLayer.Contracts;
using Email.BusinessLayer.Models;

namespace Email.BusinessLayer.Services
{
    public class EmailCreator
    {
        public string CreateMail(string nickname, EmailBuilder builder, string token = "")
        {
            builder.CreateMessage();
            builder.SetHeader();
            builder.SetText();
            EmailTemplate template = builder.EmailTemplate!;

            string mail;
            if (!string.IsNullOrEmpty(token))
                mail = $"<table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' style='max-width:600px;'><tbody><tr><td align='center'><table bgcolor='#F5F7FA' border='0' cellpadding='0' cellspacing='0' style='width:100%;'><tbody><tr><td style='width:100%;'><table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' style='width:100%;'><tbody><tr><td><table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0'style='width:100%;font-family:Arial,sans-serif;font-size:16px;line-height:24px;color:#0B1F33;'><tbody><tr><td align='left' style='max-width:600px; display: flex; align-items: center; justify-content: space-around;'><img src='https://sun9-75.userapi.com/impg/uudgcUsF0T5oQklsoDscdeub-zfNEcdKUTOPfg/9kozgGBSmVw.jpg?size=200x200&quality=96&sign=5cc9bbf2055539c5b10b02e0386b1c37&type=album'style='display: block;border: none;' width='20%'><b><span style='white-space: wrap; color: #00a3ff; font-weight: bold; justify-content: center; font-family: monospace; font-size: 18px;'>{template.Header}</span></b></td></tr><tr><td align='center' style='padding: 32px 30px 0 30px;'><span style='font-family: monospace; font-size: 18px;'>Привет, <b>{nickname}</b></span></td></tr><tr><td align='center' style='padding: 32px 30px 0 30px;'><span style='font-family: monospace; font-size: 18px;'>{template.Text}</span></td></tr><tr><td align='center' style='padding: 12px 30px 0 30px; font-family: monospace; font-size: 14px;'>Если это были не вы, то просто игнорируйте данное сообщение</td></tr><tr><td align='center' style='padding: 32px 30px 0 30px;'><div><div style='mso-hide:all;'><a href='https://localhost/api/v0/auth/confirm?token={token}'target='_blank'style='display:inline-block;padding: 14px 40px;border-radius:8px;background-color:#00a3ff;color:#FFFFFF;font-family:monospace;font-size:18px;font-weight:bold;line-height:24px;text-decoration:none;-webkit-text-size-adjust:none;'rel=' noopener noreferrer'>{template.ButtonName}</a></div></div></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table>";
            else
                mail = $"<table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' style='max-width:600px;'><tbody><tr><td align='center'><table bgcolor='#F5F7FA' border='0' cellpadding='0' cellspacing='0' style='width:100%;'><tbody><tr><td style='width:100%;'><table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' style='width:100%;'><tbody><tr><td><table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0'style='width:100%;font-family:Arial,sans-serif;font-size:16px;line-height:24px;color:#0B1F33;'><tbody><tr><td align='left' style='max-width:600px; display: flex; align-items: center; justify-content: space-around;'><img src='https://sun9-75.userapi.com/impg/uudgcUsF0T5oQklsoDscdeub-zfNEcdKUTOPfg/9kozgGBSmVw.jpg?size=200x200&quality=96&sign=5cc9bbf2055539c5b10b02e0386b1c37&type=album'style='display: block;border: none;' width='20%'><b><span style='white-space: wrap; color: #00a3ff; font-weight: bold; justify-content: center; font-family: monospace; font-size: 18px;'>{template.Header}</span></b></td></tr><tr><td align='center' style='padding: 32px 30px 0 30px;'><span style='font-family: monospace; font-size: 18px;'>Привет, <b>{nickname}</b></span></td></tr><tr><td align='center' style='padding: 32px 30px 0 30px;'><span style='font-family: monospace; font-size: 18px;'>{template.Text}</span></td></tr><tr><td align='center' style='padding: 12px 30px 0 30px; font-family: monospace; font-size: 14px;'>Если это были не вы, то просто игнорируйте данное сообщение</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table>";
            
            return mail;
        }
    }
}