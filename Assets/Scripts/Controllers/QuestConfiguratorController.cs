using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlatformerMVC
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestStoryConfig[] _questStoryConfigs;
        private QuestObjectView[] _questObjectViews;

        private List<IQuestStory> _questStories;
        private QuestController _singleQuest;

        private Dictionary<QuestType, Func<IQuestModel>> _questFactories = new Dictionary<QuestType, Func<IQuestModel>>(1);
        private Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(2);

        public QuestConfiguratorController(QuestView questView)
        {
            _questObjectViews = questView._questObjects;
            _questStoryConfigs = questView._questStoryConfigs;
            _singleQuestView = questView._singleQuest;
        }

        public void Start()
        {
            _questStoryFactories.Add(QuestStoryType.Resetable, questCollection => new ResettableQuestStoryController(questCollection));

            _questFactories.Add(QuestType.Coins, () => new CoinQuestModel());

            _singleQuest = new QuestController(_singleQuestView, new CoinQuestModel());

            _singleQuest.Reset();

            _questStories = new List<IQuestStory>();

            foreach (QuestStoryConfig questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }


        }

        private IQuestStory CreateQuestStory (QuestStoryConfig config)
        {
            List<IQuest> quests = new List<IQuest>();
            foreach (QuestConfig questConfig in config.quests)
            {
                IQuest quest = CreateQuest(questConfig);
                if (quest == null) continue;
                quests.Add(quest);
                Debug.Log("AddQuest");
            }
            return _questStoryFactories[config.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            int questID = config.id;

            QuestObjectView questView = _questObjectViews.FirstOrDefault(value => value.Id == config.id);
            if (questView == null)
            {
                Debug.Log("Cant find Quest!");
                return null;
            }
            if(_questFactories.TryGetValue(config.questType, out var factory))
            {
                IQuestModel questModel = factory.Invoke();
                return new QuestController(questView, questModel);
            }
            Debug.Log("Cant find Model!");
            return null;
        }
    }
}