using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeverBronze
{
    public static class Util
    {
        public static void getMinutesSeconds(int timestamp, out int minutes, out int seconds)
        {
            seconds = (int)(timestamp / (1000)) % 60;
            minutes = (int)timestamp / (60 * 1000);
        }
    }

    public class Match
    {
        public long matchId { get; set; }
        public string region { get; set; }
        public string platformId { get; set; }
        public string matchMode { get; set; }
        public string matchType { get; set; }
        public long matchCreation { get; set; }
        public int matchDuration { get; set; }
        public string queueType { get; set; }
        public int mapId { get; set; }
        public string season { get; set; }
        public string matchVersion { get; set; }
        public Participant[] participants { get; set; }
        public Participantidentity[] participantIdentities { get; set; }
        public Team[] teams { get; set; }
        public Timeline timeline { get; set; }
    }

    public class Timeline
    {
        public Frame[] frames { get; set; }
        public int frameInterval { get; set; }
    }

    class FrameConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Frame));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Frame frame = new Frame();

            /*
             * Events
             * 
             */
            frame.frameEvents = new List<FrameEvent>();

            if (jo["events"] != null)
            {
                foreach (JObject frameEvent in jo["events"])
                {
                    frame.frameEvents.Add(frameEvent.ToObject<FrameEvent>(serializer));
                }
            }

            /*
             * Frame Participants
             * 
             */
            frame.frameParticipants = new List<FrameParticipant>();

            if (jo["participantFrames"] != null)
            {
                foreach (JProperty participantFrame in jo["participantFrames"])
                {
                    var frameParticipant = participantFrame.Value.ToObject<FrameParticipant>(serializer);
                    frameParticipant.timestamp = (int)jo["timestamp"];
                    frame.frameParticipants.Add(frameParticipant);
                }
            }

            return frame;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    [JsonConverter(typeof(FrameConverter))]
    public class Frame
    {
        public List<FrameEvent> frameEvents { get; set; }
        public List<FrameParticipant> frameParticipants { get; set; }

        public List<List<string>> getAllFrameEvents()
        {
            var list = new List<List<string>>();
            foreach (var frameEvent in frameEvents)
            {
                list.Add(frameEvent.getFrameEvent());
            }
            return list;
        }

        public List<List<string>> getAllFrameParticipants()
        {
            var list = new List<List<string>>();
            foreach (var frameParticipant in frameParticipants)
            {
                list.Add(frameParticipant.getFrameParticipant());
            }
            return list;
        }
    }

    public class FrameEvent
    {
        public string eventType { get; set; }
        public int timestamp { get; set; }
        public int itemId { get; set; }
        public int participantId { get; set; }

        public List<string> getFrameEvent()
        {
            int minutes, seconds;
            Util.getMinutesSeconds(timestamp, out minutes, out seconds);
            return new List<string> { string.Format("{0:00}:{1:00}", minutes, seconds), participantId.ToString(), itemId.ToString(), eventType };
        }
    }

    public class FrameParticipant
    {
        public int timestamp { get; set; }
        public int participantId { get; set; }
        public Position position { get; set; }
        public int currentGold { get; set; }
        public int totalGold { get; set; }
        public int level { get; set; }
        public int xp { get; set; }
        public int minionsKilled { get; set; }
        public int jungleMinionsKilled { get; set; }
        public int dominionScore { get; set; }
        public int teamScore { get; set; }
        
        public List<string> getFrameParticipant()
        {
            int minutes, seconds;
            Util.getMinutesSeconds(timestamp, out minutes, out seconds);
            return new List<string> { string.Format("{0:00}:{1:00}", minutes, seconds), participantId.ToString(), position?.x.ToString(), position?.y.ToString(), level.ToString(), xp.ToString(), totalGold.ToString() };
        }
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Participant
    {
        public int teamId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public int championId { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public DeltaTimeline timeline { get; set; }
        public Mastery[] masteries { get; set; }
        public Stats stats { get; set; }
        public int participantId { get; set; }
        public Rune[] runes { get; set; }
    }

    public class DeltaTimeline
    {
        public Delta creepsPerMinDeltas { get; set; }
        public Delta xpPerMinDeltas { get; set; }
        public Delta goldPerMinDeltas { get; set; }
        public Delta damageTakenPerMinDeltas { get; set; }
        public string role { get; set; }
        public string lane { get; set; }
    }

    public class Delta
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
        public float thirtyToEnd { get; set; }
    }

    public class Stats
    {
        public bool winner { get; set; }
        public int champLevel { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int item6 { get; set; }
        public int kills { get; set; }
        public int doubleKills { get; set; }
        public int tripleKills { get; set; }
        public int quadraKills { get; set; }
        public int pentaKills { get; set; }
        public int unrealKills { get; set; }
        public int largestKillingSpree { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int totalDamageDealt { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int totalDamageTaken { get; set; }
        public int largestCriticalStrike { get; set; }
        public int totalHeal { get; set; }
        public int minionsKilled { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int neutralMinionsKilledTeamJungle { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int goldEarned { get; set; }
        public int goldSpent { get; set; }
        public int combatPlayerScore { get; set; }
        public int objectivePlayerScore { get; set; }
        public int totalPlayerScore { get; set; }
        public int totalScoreRank { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public int magicDamageDealt { get; set; }
        public int physicalDamageDealt { get; set; }
        public int trueDamageDealt { get; set; }
        public int magicDamageTaken { get; set; }
        public int physicalDamageTaken { get; set; }
        public int trueDamageTaken { get; set; }
        public bool firstBloodKill { get; set; }
        public bool firstBloodAssist { get; set; }
        public bool firstTowerKill { get; set; }
        public bool firstTowerAssist { get; set; }
        public bool firstInhibitorKill { get; set; }
        public bool firstInhibitorAssist { get; set; }
        public int inhibitorKills { get; set; }
        public int towerKills { get; set; }
        public int wardsPlaced { get; set; }
        public int wardsKilled { get; set; }
        public int largestMultiKill { get; set; }
        public int killingSprees { get; set; }
        public int totalUnitsHealed { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
    }

    public class Mastery
    {
        public int masteryId { get; set; }
        public int rank { get; set; }
    }

    public class Rune
    {
        public int runeId { get; set; }
        public int rank { get; set; }
    }

    public class Participantidentity
    {
        public int participantId { get; set; }
    }

    public class Team
    {
        public int teamId { get; set; }
        public bool winner { get; set; }
        public bool firstBlood { get; set; }
        public bool firstTower { get; set; }
        public bool firstInhibitor { get; set; }
        public bool firstBaron { get; set; }
        public bool firstDragon { get; set; }
        public bool firstRiftHerald { get; set; }
        public int towerKills { get; set; }
        public int inhibitorKills { get; set; }
        public int baronKills { get; set; }
        public int dragonKills { get; set; }
        public int riftHeraldKills { get; set; }
        public int vilemawKills { get; set; }
        public int dominionVictoryScore { get; set; }
    }
}