namespace App.Domain.Enum
{
    public enum Status
    {
        Pending = 1, // A tarefa foi criada, mas ainda não foi iniciada.
        InProgress = 2, // A tarefa está em andamento.
        Completed = 3, // A tarefa foi concluída com sucesso.
        OnHold = 4, // A tarefa está pausada ou aguardando algum tipo de ação antes de ser retomada.
        Canceled = 5, // A tarefa foi cancelada e não será mais realizada.
        Overdue = 6, // A tarefa passou da data de vencimento e não foi concluída.
    }
}
