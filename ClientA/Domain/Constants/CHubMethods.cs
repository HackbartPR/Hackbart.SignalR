namespace ClientA.Domain.Constants
{
    /// <summary>
    /// Constantes representando os métodos de envios do Hub no servidor
    /// </summary>
    public static class CHubMethods
    {
        #region - ENVIAR MENSAGEM
        public const string SEND_MESSAGE_TO_ALL = "SendMessageToAll";

        public const string SEND_MESSAGE_TO_CALLER = "SendMessageToCaller";

        public const string SEND_MESSAGE_TO_GROUP = "SendMessageToGroup";
        #endregion

        #region - GRUPOS
        public const string ADD_TO_GROUP = "AddToGroup";

        public const string REMOVE_TO_GROUP = "RemoveFromGroup";
        #endregion
    }
}
