using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

interface IHero
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
    int GetX();
    int GetY();
}

interface IObserver
{
    void Update(int heroX, int heroY);
}

class Hero : IHero
{
    private List<IObserver> observers = new List<IObserver>();
    private int x;
    private int y;
    private PictureBox pictureBox;

    public Hero(PictureBox pictureBox)
    {
        this.pictureBox = pictureBox;
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(x, y);
        }
    }

    public void Move(int newX, int newY)
    {
        x = newX;
        y = newY;
        pictureBox.Location = new Point(x, y);
        Notify();
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
}


class Enemy : IObserver
{
    private int x;
    private int y;
    private PictureBox pictureBox;

    public Enemy(PictureBox pictureBox)
    {
        this.pictureBox = pictureBox;
    }

    public void Update(int heroX, int heroY)
    {
        if (heroX > x)
        {
            x++;
        }
        else if (heroX < x)
        {
            x--;
        }
        if (heroY > y)
        {
            y++;
        }
        else if (heroY < y)
        {
            y--;
        }

        pictureBox.Location = new Point(x, y);
    }
}