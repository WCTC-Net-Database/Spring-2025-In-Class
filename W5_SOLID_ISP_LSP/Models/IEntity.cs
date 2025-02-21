namespace W5_SOLID_ISP_LSP.Models
{
    public interface IEntity
    {
        void Move();
        void Attack();
    }

    public interface IFlyable
    {
        void Fly();
    }
}
