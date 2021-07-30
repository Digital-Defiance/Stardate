namespace Stardate
{
using System;
    using System.Collections.Generic;

    /// <summary>
    /// Direct C# Port of Dan Hunsaker's Timeline
    /// https://raw.githubusercontent.com/danhunsaker/calends/master/calendars/stardate.go
    /// STARDATE (Yes, from Star Trek™) CALENDAR
    ///
    /// The science fiction universe of Star Trek™ introduced a calendar system which
    /// was simultaneously futuristic(for the time) and arbitrary.Over the decades
    /// since its initial use on screen, especially with the growing popularity of the
    /// franchise, the "stardate" has been analyzed and explored and refined into a
    /// number of different variants, each trying to reconcile the arbitrariness of the
    /// on-screen system into something consistent and usable.
    /// 
    /// This calendar system implementation is an attempt to combine all these variants
    /// into a single system, using the format parameter to select which variant to use.
    /// It was originally ported in 2018 from code by Aaron Chong (2015 version), under
    /// provisions of the MIT License.My thanks for Aaron's use of the MIT License on
    /// the original code, which allowed me to port it cleanly and legally.
    /// 
    /// Original source: http://rinsanity.weebly.com/files/theme/stardate_public.js
    /// </summary>
    public class Stardate
    {
        public StardateTimeline Timeline { get; }

        public const float jdcBaseGregorian = 1721425.5F;

        public static readonly float[] stardateMainCutoffs = {
            2510717.5F,
            2550185.5F,
            2555185.5F,
            2569517.5F,
        };

        public static readonly float[] stardateMainValues = {
            0.0F,
            197340.0F,
            197840.0F,
            2100000.0F,
        };

        public static readonly float[] stardateMainRates = {
            5.0F,
            0.1F,
            0.5F,
            (1000.0F / 365.2425F),
        };

        public static readonly float[] stardateKennedyCutoffs = {
            2548704.5F, // 2266-01-06
	        2550229.5F, // 2270-03-11
	        2555479.5F, // 2284-07-25
	        2575499.5F, // 2339-05-19
        };

        public static readonly float[] stardateKennedyValues = {
            0.0F,
            7320.0F,
            8076.0F,
            17685.6F,
        };

        public static readonly float[] stardateKennedyRates = {
            4.8F,
            0.144F,
            0.48F,
            (144.0F / 55.0F),
        };

        public const float stardatePughEpoch = 2569517.5F;

        public static readonly Dictionary<StardateTimeline, float> stardateFixedRateCutoffs = new Dictionary<StardateTimeline, float>() {
            { StardateTimeline.GuideEquiv, 2446991.5F },
            { StardateTimeline.GuideTNG, 2567877.0F },
            { StardateTimeline.GuideTOS, 2548448.5F },
            { StardateTimeline.GuideOldTNG, 2569296.5F },
            { StardateTimeline.GuideOldTOS,2569296.5F },
            { StardateTimeline.Aldrich, 2569517.5F },
            { StardateTimeline.RedDragon, 2569517.5F },
            { StardateTimeline.STOAcademy, 2455340.5F },
            { StardateTimeline.STOTom, 2423199.5F },
            { StardateTimeline.STOAnthodev, 2423199.5F },
        };

        public static readonly Dictionary<StardateTimeline, float> stardateFixedRateRates = new Dictionary<StardateTimeline, float>() {
            { StardateTimeline.GuideEquiv, 1000 / 365.25F },
            { StardateTimeline.GuideTNG, 86400 / 34367.0564F },
            { StardateTimeline.GuideTOS, 2635.10833F / 365.2422F },
            { StardateTimeline.GuideOldTNG, 1000 / 365.2422F },
            { StardateTimeline.GuideOldTOS, 1000 / 365.2422F },
            { StardateTimeline.Aldrich, 1000 / 365.2422F },
            { StardateTimeline.RedDragon, 2.73973F },
            { StardateTimeline.STOAcademy, 2.736F },
            { StardateTimeline.STOTom, 2.7378508F },
            { StardateTimeline.STOAnthodev, 1000 / 365.2527F },
        };

        public static readonly Dictionary<StardateTimeline, float> stardateFixedRateOffsets = new Dictionary<StardateTimeline, float>() {
            { StardateTimeline.GuideEquiv, 41000F },
            { StardateTimeline.GuideTNG, 0F },
            { StardateTimeline.GuideTOS, 0F },
            { StardateTimeline.GuideOldTNG, 0F },
            { StardateTimeline.GuideOldTOS, 0F },
            { StardateTimeline.Aldrich, 0F },
            { StardateTimeline.RedDragon, 0F },
            { StardateTimeline.STOAcademy, 87998.3079F },
            { StardateTimeline.STOTom, 0F },
            { StardateTimeline.STOAnthodev, 0F },
        };

        public static DateTime stardateToInternal(string date, StardateTimeline timeline) {
            float jdc;
            switch (timeline) {
                case StardateTimeline.Main:
                    jdc = stardateMainToJDC(date);
                    break;
                /*
            case StardateTimeline.Kennedy:
                return stardateKennedyToJDC(date);
            case StardateTimeline.Pugh90s:
                return stardatePughToJDC(date, false);
            case StardateTimeline.PughFixed:
                return stardatePughToJDC(date, true);
            case StardateTimeline.Schmidt:
                return stardateSchmidtToJDC(date);
            case StardateTimeline.GuideEquiv:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.GuideTNG:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.GuideTOS:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.GuideOldTNG:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.GuideOldTOS:
                    throw new ArgumentException(nameof(timeline));
            case StardateTimeline.Aldrich:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.RedDragon:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.STOHynes:
                return stardateSTOHynesToJDC(date);
                */
            case StardateTimeline.STOAcademy:
                jdc = stardateFixedRateToJDC(date, timeline);
                break;
                /*
            case StardateTimeline.STOTom:
                return stardateFixedRateToJDC(date, timeline);
            case StardateTimeline.STOAnthodev:
                return stardateFixedRateToJDC(date, timeline);
                */
                default:
                    throw new ArgumentException(nameof(timeline));
            }
            
            return Jdc.JdcToInternal(jdc, JdcFormat.Full);
        }
        //public static float stardateJDCToFixedRate(float jdc, StardateTimeline mode) {
        // return jdc + stardateFixedRateOffsets[mode] + jdc.Mul(jdc.Sub(&jdc, stardateFixedRateCutoffs[mode]), stardateFixedRateRates[mode])).String()
        //}

        public static float stardateFixedRateToJDC(string stardate, StardateTimeline mode)
        {
            throw new NotImplementedException();
        }

        //public static float stardateFixedRateToJDC(string stardate, StardateTimeline mode) {
        //	 var date := big.ParseFloat(stardate, 10, 188, big.ToNearestAway)
        //	return *date.Add(date.Quo(date.Sub(date, stardateFixedRateOffsets[mode]), stardateFixedRateRates[mode]), stardateFixedRateCutoffs[mode])
        //}

        public static float stardateMainToJDC(string stardate) {
            long region, issue;

            var stardateString = new StardateString(stardate);

            var sdBigFloat = stardateString.Stardate;
            issue = stardateString.Issue.HasValue ? stardateString.Issue.Value : 0;

            if (issue >= 21) {
                region = 3;

                sdBigFloat += (100000f * issue);
            } else {
                sdBigFloat += (10000f * issue);
                region = 0;
                while (region < 2 && sdBigFloat.CompareTo(stardateMainValues[region + 1]) >= 0)
                {
                    region++;
                }
            }
            return sdBigFloat + stardateMainCutoffs[region] + ((sdBigFloat - stardateMainValues[region]) / stardateMainRates[region]);
        }

        public string stardateJDCToMain(float jdc) {
            var region = 0;

            long issue;
            var stardate = 0.0F;
            string format;
            while (region < 3 && jdc.CompareTo(stardateMainCutoffs[region + 1]) >= 0) {
                region++;
            }

            stardate += stardateMainValues[region] + ((jdc - stardateMainCutoffs[region]) * stardateMainRates[region]);

            if (region == 3) {
                issue = ((long)(stardate / 100000.0f));
                stardate -= (100000F * issue);
                return string.Format("[{0}]{1:#####.0######}", issue, stardate);
            }
            else
            {
                issue = ((long)(stardate / 10000.0F));
                stardate -= (10000F * issue);
                if (stardate.CompareTo(0F) < 0) {
                    issue--;
                   stardate += 10000F;
                }
                return string.Format("[{0}]{1:####.0######}", issue, stardate);
            }
        }
    }
}
