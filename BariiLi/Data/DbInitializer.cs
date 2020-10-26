using BariiLi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BariiLiContext context)
        {
            context.Database.EnsureCreated();
            if (context.MedicalTeams.Any())
            {
                return; //DB is full already
            }

            //DB is empty
            var medicalTeams = new MedicalTeam[]
            {
                new MedicalTeam{ MTId="318465913", fullName="אייל משה", gender="זכר", specialization="ניתוחי אף", availability=DateTime.Parse("8:00-20:00"), location="אסותא אשדוד, בלינסון פתח תקווה", previousExprience=10},
                new MedicalTeam{ MTId="318465912", fullName="ג'סטין צ'מברס", gender="זכר", specialization="ניתוחי אף", availability=DateTime.Parse("20:01-7:59"), location="אסף הרופא ראשון לציון, בית הרופאים תל אביב", previousExprience=15},
                new MedicalTeam{ MTId="318465914", fullName="פטריק דמפסי", gender="זכר", specialization="הזרקות", availability=DateTime.Parse("10:00-22:00"), location="אסותא חיפה, מרכז רפואי זיו צפת", previousExprience=5},
                new MedicalTeam{ MTId="318465919", fullName="גדי גולדשטיין", gender="זכר", specialization="הזרקות", availability=DateTime.Parse("22:01-09:59"), location="בית חולים רמב''ם חיפה, מרכז רפואי כרמל חיפה", previousExprience=20},
                new MedicalTeam{ MTId="316465920", fullName="נורית לרר בן חמו", gender="נקבה", specialization="מתיחת פנים", availability=DateTime.Parse("8:30-20:30"), location="בית חולים וולפסון חולון, אסף הרופא ראשון לציון", previousExprience=25},
                new MedicalTeam{ MTId="316385919", fullName="הלן קטלין", gender="נקבה", specialization="מתיחת פנים", availability=DateTime.Parse("20:30-8:29"), location="מרכז רפואי קפלן רחובות, אסותא ראשון לציון", previousExprience=15},
                new MedicalTeam{ MTId="317165717", fullName="גיל לחמי", gender="זכר", specialization="גסטרו", availability=DateTime.Parse("7:30-19:30"), location="אסותא אשדוד, בלינסון פתח תקווה", previousExprience=7},
                new MedicalTeam{ MTId="247665729", fullName="אלון משה", gender="זכר", specialization="גסטרו", availability=DateTime.Parse("19:31-7:29"), location="אסותא תל אביב, תל השומר רמת גן", previousExprience=15},
                new MedicalTeam{ MTId="022165714", fullName="שקד רואי", gender="נקבה", specialization="אורתופדיה", availability=DateTime.Parse("9:30-21:30"), location="בלינסון פתח תקווה", previousExprience=5},
                new MedicalTeam{ MTId="319165896", fullName="שני כהן", gender="נקבה", specialization="אורתופדיה", availability=DateTime.Parse("21:31-09:29"), location="קפלן רחובות, הדסה עין כרם ירושלים", previousExprience=12},
                new MedicalTeam{ MTId="205465921", fullName="דני גלמור", gender="זכר", specialization="רפואת שיניים", availability=DateTime.Parse("06:45-18:45"), location="מרכז רפואי שיבא רמת גן, מאיר כפר סבא", previousExprience=16},
                new MedicalTeam{ MTId="022165847", fullName="אריק בורנשטיין", gender="זכר", specialization="רפואת שיניים", availability=DateTime.Parse("18:46-06:44"), location="קפלן רחובות, מרפאה פרטית נהריה", previousExprience=24},
                new MedicalTeam{ MTId="315145815", fullName="אלכס שרמן", gender="זכר", specialization="רפואה כללית", availability=DateTime.Parse("9:00-21:00"), location="מעייני הישועה בני ברק, מאיר כפר סבא", previousExprience=10},
                new MedicalTeam{ MTId="311145624", fullName="מאיה שאול", gender="נקבה", specialization="רפואה כללית", availability=DateTime.Parse("21:01-08:59"), location="אסותא אשדוד, הדסה עין כרם ירושלים", previousExprience=13}

            };
            
            foreach (MedicalTeam mt in medicalTeams)
            {
                context.MedicalTeams.Add(mt);  
            }
            context.SaveChanges();
        }
    }
}
