
namespace FSM
{
    /// <summary>
    /// 유한상태기계 인터페이스 
    /// </summary>
    /// <typeparam name="T">형식 매개변수의 이름을 T로 정의</typeparam>
    public interface IState<T>
    {
        void Enter();
        void Excute();
        void Exit();

        T StateID
        { get; }
    }
}