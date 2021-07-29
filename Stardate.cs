namespace Stardate
{
    using System.Collections.Generic;
    /// <summary>
    /// Direct C# Port of Dan Hunsaker's Timeline
    /// https://raw.githubusercontent.com/danhunsaker/calends/master/calendars/stardate.go
    //
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

        public readonly float[] stardateMainCutoffs = {
	        2510717.5F,
	        2550185.5F,
	        2555185.5F,
	        2569517.5F,
        };

        public readonly float[] stardateMainValues = {
            0.0F,
            197340.0F,
            197840.0F,
            2100000.0F,
        };

        public readonly float[] stardateMainRates = {
            5.0F,
            0.1F,
            0.5F,
            (1000.0F / 365.2425F),
        };

        public readonly float[] stardateKennedyCutoffs = {
	        2548704.5F, // 2266-01-06
	        2550229.5F, // 2270-03-11
	        2555479.5F, // 2284-07-25
	        2575499.5F, // 2339-05-19
        };

        public readonly float[] stardateKennedyValues = {
            0.0F,
            7320.0F,
            8076.0F,
            17685.6F,
        };

        public readonly float[] stardateKennedyRates = {
            4.8F,
            0.144F,
            0.48F,
            (144.0F / 55.0F),
        };

        public const float stardatePughEpoch = 2569517.5F;

        public readonly Dictionary<StardateTimeline, float> stardateFixedRateCutoffs = new Dictionary<StardateTimeline, float>() {
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

        public readonly Dictionary<StardateTimeline, float> stardateFixedRateRates = new Dictionary<StardateTimeline, float>() {
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

        public readonly Dictionary<StardateTimeline, float> stardateFixedRateOffsets = new Dictionary<StardateTimeline, float>() {
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
    }
}
