﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace front_bot.src.common {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class BotMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BotMessages() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("front_bot.src.common.BotMessages", typeof(BotMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Введите вашу электронную почту. .
        /// </summary>
        internal static string EnterEmail {
            get {
                return ResourceManager.GetString("EnterEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Введите ваш пароль.
        /// </summary>
        internal static string EnterPass {
            get {
                return ResourceManager.GetString("EnterPass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Пришлите JSON файл, содержащий схему бота.
        /// </summary>
        internal static string SendBotScheme {
            get {
                return ResourceManager.GetString("SendBotScheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Здравствуйте! Данный бот разработан в рамках курсового проекта по курсу &quot;Базы данных&quot;.
        ///
        ///Команды бота:                           
        ////newbot - create a new bot
        ////mybots - edit your bots.
        /// </summary>
        internal static string Start {
            get {
                return ResourceManager.GetString("Start", resourceCulture);
            }
        }
    }
}
