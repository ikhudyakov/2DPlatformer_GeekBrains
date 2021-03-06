using System;

namespace PlatformerMVC
{

    public class QuestController : IQuest
    {
        private QuestObjectView _view;
        private IQuestModel _model;
        private bool _active;

        public QuestController(QuestObjectView view, IQuestModel model)
        {
            _view = view;
            _model = model;
        }

        private void OnContact(LevelObjectView arg)
        {
            bool completed = _model.TryComplete(arg.gameObject);
            if (completed) Complete();
        }

        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        private void Complete()
        {
            if (!_active) return;

            _active = false;
            _view.OnLevelObjectContact -= OnContact;
            _view.Complete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        public void Reset()
        {
            if (_active) return;

            _active = true;
            _view.OnLevelObjectContact += OnContact;
            _view.Activate();
        }
        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}