using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeverBronze
{
    public class Match
    {
        private readonly long matchId;
        private readonly string region;
        private readonly string platformId;
        private readonly string matchMode;
        private readonly string matchType;
        private readonly long matchCreation;
        private readonly int matchDuration;
        private readonly string queueType;
        private readonly int mapId;
        private readonly string season;
        private readonly string matchVersion;
        private readonly Participant[] participants;
        private readonly ParticipantIdentity[] participantIdentities;
        private readonly Team[] teams;
        private readonly Timeline timeline;
    }

    public class Timeline
    {
        private readonly Frame[] frames;
        private readonly int frameInterval;
    }

    public class Frame
    {
        private readonly ParticipantFrame[] participantFrames;
        private readonly int timestamp;
        private readonly Event[] events;

        public void printAll()
        {
            foreach (var participantFrame in participantFrames)
            {
                participantFrame.print();
            }
        }
    }
    
    public class ParticipantFrame
    {
        private readonly int participantId;
        private readonly Position position;
        private readonly int currentGold;
        private readonly int totalGold;
        private readonly int level;
        private readonly int xp;
        private readonly int minionsKilled;
        private readonly int jungleMinionsKilled;
        private readonly int dominionScore;
        private readonly int teamScore;

        public void print()
        {
            Console.WriteLine(string.Format("[MM:SS] {0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                participantId, position, currentGold, totalGold, level, xp, minionsKilled, jungleMinionsKilled, dominionScore, teamScore));
        }
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    
    public class Event
    {
        private readonly string eventType;
        private readonly int timestamp;
        private readonly int itemId;
        private readonly int participantId;
        private readonly int skillSlot;
        private readonly string levelUpType;
        private readonly int itemBefore;
        private readonly int itemAfter;
        private readonly int killerId;
        private readonly int victimId;
        private readonly Position position;
        private readonly int[] assistingParticipantIds;
        private readonly int teamId;
        private readonly string laneType;
        private readonly string buildingType;
        private readonly string towerType;
        private readonly string monsterType;

        public void print()
        {
            Console.WriteLine(string.Format("[MM:SS] ({0}, {1}) {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15}",
                position.x, position.y, eventType, itemId, participantId, skillSlot, levelUpType, itemBefore, itemAfter,
                killerId, victimId, teamId, laneType, buildingType, towerType, monsterType));
        }
    }

    public class Participant
    {
        private readonly int teamId;
        private readonly int spell1Id;
        private readonly int spell2Id;
        private readonly int championId;
        private readonly string highestAchievedSeasonTier;
        private readonly TimelineDeltas timeline;
        private readonly Mastery[] masteries;
        private readonly Stats stats;
        private readonly int participantId;
        private readonly Rune[] runes;
    }

    public class TimelineDeltas
    {
        private readonly CreepsPerMinDeltas creepsPerMinDeltas;
        private readonly XpPerMinDeltas xpPerMinDeltas;
        private readonly GoldPerMinDeltas goldPerMinDeltas;
        private readonly DamageTakenPerMinDeltas damageTakenPerMinDeltas;
        private readonly string role;
        private readonly string lane;
    }

    public class CreepsPerMinDeltas
    {
        private readonly float zeroToTen;
        private readonly float tenToTwenty;
    }

    public class XpPerMinDeltas
    {
        private readonly float zeroToTen;
        private readonly float tenToTwenty;
    }

    public class GoldPerMinDeltas
    {
        private readonly float zeroToTen;
        private readonly float tenToTwenty;
    }

    public class DamageTakenPerMinDeltas
    {
        private readonly float zeroToTen;
        private readonly float tenToTwenty;
    }

    public class Stats
    {
        private readonly bool winner;
        private readonly int champLevel;
        private readonly int item0;
        private readonly int item1;
        private readonly int item2;
        private readonly int item3;
        private readonly int item4;
        private readonly int item5;
        private readonly int item6;
        private readonly int kills;
        private readonly int doubleKills;
        private readonly int tripleKills;
        private readonly int quadraKills;
        private readonly int pentaKills;
        private readonly int unrealKills;
        private readonly int largestKillingSpree;
        private readonly int deaths;
        private readonly int assists;
        private readonly int totalDamageDealt;
        private readonly int totalDamageDealtToChampions;
        private readonly int totalDamageTaken;
        private readonly int largestCriticalStrike;
        private readonly int totalHeal;
        private readonly int minionsKilled;
        private readonly int neutralMinionsKilled;
        private readonly int neutralMinionsKilledTeamJungle;
        private readonly int neutralMinionsKilledEnemyJungle;
        private readonly int goldEarned;
        private readonly int goldSpent;
        private readonly int combatPlayerScore;
        private readonly int objectivePlayerScore;
        private readonly int totalPlayerScore;
        private readonly int totalScoreRank;
        private readonly int magicDamageDealtToChampions;
        private readonly int physicalDamageDealtToChampions;
        private readonly int trueDamageDealtToChampions;
        private readonly int visionWardsBoughtInGame;
        private readonly int sightWardsBoughtInGame;
        private readonly int magicDamageDealt;
        private readonly int physicalDamageDealt;
        private readonly int trueDamageDealt;
        private readonly int magicDamageTaken;
        private readonly int physicalDamageTaken;
        private readonly int trueDamageTaken;
        private readonly bool firstBloodKill;
        private readonly bool firstBloodAssist;
        private readonly bool firstTowerKill;
        private readonly bool firstTowerAssist;
        private readonly bool firstInhibitorKill;
        private readonly bool firstInhibitorAssist;
        private readonly int inhibitorKills;
        private readonly int towerKills;
        private readonly int wardsPlaced;
        private readonly int wardsKilled;
        private readonly int largestMultiKill;
        private readonly int killingSprees;
        private readonly int totalUnitsHealed;
        private readonly int totalTimeCrowdControlDealt;
    }

    public class Mastery
    {
        private readonly int masteryId;
        private readonly int rank;
    }

    public class Rune
    {
        private readonly int runeId;
        private readonly int rank;
    }

    public class ParticipantIdentity
    {
        private readonly int participantId;
        private readonly Player player;
    }

    public class Player
    {
        private readonly int summonerId;
        private readonly string summonerName;
        private readonly string matchHistoryUri;
        private readonly int profileIcon;
    }

    public class Team
    {
        private readonly int teamId;
        private readonly bool winner;
        private readonly bool firstBlood;
        private readonly bool firstTower;
        private readonly bool firstInhibitor;
        private readonly bool firstBaron;
        private readonly bool firstDragon;
        private readonly bool firstRiftHerald;
        private readonly int towerKills;
        private readonly int inhibitorKills;
        private readonly int baronKills;
        private readonly int dragonKills;
        private readonly int riftHeraldKills;
        private readonly int vilemawKills;
        private readonly int dominionVictoryScore;
        private readonly Ban[] bans;
    }

    public class Ban
    {
        private readonly int championId;
        private readonly int pickTurn;
    }
}