using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Language
{
    public enum LanguageType
    {
        [Description("English")]
        [Display(Name = "en-US", ShortName = "en")]
        English = 1,

        [Description("简体中文")]
        [Display(Name = "zh-CN", ShortName = "zh")]
        Chinese = 2,

        [Description("Français")]
        [Display(Name = "fr-FR", ShortName = "fr")]
        French = 3,

        [Description("Deutsch")]
        [Display(Name = "de-DE", ShortName = "de")]
        German = 4,

        [Description("Italiano")]
        [Display(Name = "it-IT", ShortName = "it")]
        Italian = 5,

        [Description("日本語")]
        [Display(Name = "ja-JP", ShortName = "jp")]
        Japanese = 6,

        [Description("Español")]
        [Display(Name = "es-ES", ShortName = "es")]
        Spanish = 7,

        [Description("한국어")]
        [Display(Name = "ko-KR", ShortName = "kr")]
        Korean = 8,

    }
}
