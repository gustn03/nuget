using System;
using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

namespace nuget
{
    class Program
    {   
        class Block{
            public Rectangle shape = new Rectangle();
            public Color color = Color.BLUE;
        }

        static void Main(string[] args)
        {
            Raylib.InitWindow(1080, 920, "Kaizo tetris");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {   
                Random generator = new Random();
                int calamity = 0;

                int select = 440;
                int scene = 1;

                float timer = 0;
                float timerMax = 15;
                float blockTimer = 0;
                float blockTimerMax = 1.5f;
                //meny
                while(scene == 1)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                    {
                        select = 540;
                    }

                    else if(Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                    {
                        select = 440;
                    }

                    if (select == 440 && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        scene = 2;
                    }

                    else if(select == 540 && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        Raylib.CloseWindow();
                    }

                    Raylib.BeginDrawing();
                    Raylib.DrawText("Tetris", 100, 200, 150, Color.BLACK);
                    Raylib.DrawText("(For babies lul)", 100, 350, 50, Color.BLACK); // planen var att göra spelet actually svårt men lyckades aldrig lista ut hur
                    Raylib.DrawCircle(360, select, 10, Color.BLACK);
                    Raylib.DrawText("Play?", 400, 400,80, Color.BLACK);
                    Raylib.DrawText("QUIT? (coward)", 400, 500, 80, Color.BLACK);
                    Raylib.ClearBackground(Color.BLUE);
                    Raylib.EndDrawing();
                    }

                int blockX1 = 540;
                int blockX2 = 540;
                int blockX3 = 540;
                int blockX4 = 540;
                int blockY1 = 20;
                int blockY2 = 20;
                int blockY3 = 20;
                int blockY4 = 20;
                
                //spel
                while(scene == 2)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
                    {
                        scene = 1;
                    }
                    int x1 = blockX1;
                    int x2 = blockX2;
                    int x3 = blockX3;
                    int x4 = blockX4;
                    int y1 = blockY1;
                    int y2 = blockY2;
                    int y3 = blockY3;
                    int y4 = blockY4;

                    Block sqr1 = new Block();
                    sqr1.shape.x = x1;
                    sqr1.shape.y = y1;
                    sqr1.shape.width = 40;
                    sqr1.shape.height = 40;
                    sqr1.color = Color.BLUE;

                    Block sqr2 = new Block();
                    sqr2.shape.x = x2;
                    sqr2.shape.y = y2;
                    sqr2.shape.width = 40;
                    sqr2.shape.height = 40;
                    sqr2.color = Color.RED;

                    Block sqr3 = new Block();
                    sqr3.shape.x = x3;
                    sqr3.shape.y = y3;
                    sqr3.shape.width = 40;
                    sqr3.shape.height = 40;
                    sqr3.color = Color.MAGENTA;

                    Block sqr4 = new Block();
                    sqr4.shape.x = x4;
                    sqr4.shape.y = y4;
                    sqr4.shape.width = 40;
                    sqr4.shape.height = 40;
                    sqr4.color = Color.ORANGE;

                    List<Block> blocks = new List<Block>();
                    blocks.Add(sqr1);
                    blocks.Add(sqr2);
                    blocks.Add(sqr3);
                    blocks.Add(sqr4);

                    Rectangle bottom = new Rectangle(0, 770, 1080, 250);
                    Rectangle left = new Rectangle(0,0,200,920);
                    Rectangle right = new Rectangle(880,0,200,920);
                    //gör att blocken rör sig nedåt
                    blockTimer += Raylib.GetFrameTime();
                    if (blockTimer >= blockTimerMax && blockY1 < 730)
                    {
                        blockY1 = blockY1 + 40;
                        blockTimer = blockTimer -1.5f;
                    }
                    blockTimer += Raylib.GetFrameTime();

                    blockTimer += Raylib.GetFrameTime();
                    if (blockTimer >= blockTimerMax && blockY1 == 730)
                    {
                        blockY2 = blockY2 + 40;
                        blockTimer = blockTimer -1.5f;
                    }
                    blockTimer += Raylib.GetFrameTime();

                    blockTimer += Raylib.GetFrameTime();
                    if (blockTimer >= blockTimerMax && blockY2 == 730)
                    {
                        blockY3 = blockY3 + 40;
                        blockTimer = blockTimer -1.5f;
                    }
                    blockTimer += Raylib.GetFrameTime();

                    blockTimer += Raylib.GetFrameTime();
                    if (blockTimer >= blockTimerMax && blockY3 == 730)
                    {
                        blockY4 = blockY4 + 40;
                        blockTimer = blockTimer -1.5f;
                    }
                    blockTimer += Raylib.GetFrameTime();

                    if (blockY1 > 730)
                    {
                        blockY1 = 730;
                    }

                    if (blockY2 > 730)
                    {
                        blockY2 = 730;
                    }

                    if (blockY3 > 730)
                    {
                        blockY3 = 730;
                    }

                    if (blockY4 > 730)
                    {
                        blockY4 = 730;
                    }

                    timer += Raylib.GetFrameTime();
                    if (timer >= timerMax)
                    {
                        calamity = generator.Next(1,5);
                        timer = timer - 15;
                    }
                    timer += Raylib.GetFrameTime();
                    //flyttar blocken vänster
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && blockY1 != 730)
                    {
                        blockX1 = blockX1 - 20;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && blockY1 == 730 && blockY2 != 730)
                    {
                        blockX2 = blockX2 - 20;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && blockY2 == 730 && blockY3 != 730)
                    {
                        blockX3 = blockX3 - 20;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && blockY3 == 730 && blockY4 != 730)
                    {
                        blockX4 = blockX4 - 20;
                    }
                    //gör att blocken inte går utanför
                    if (blockX1 < 200)
                    {
                        blockX1 = 200;
                    }

                    if (blockX2 < 200)
                    {
                        blockX2 = 200;
                    }

                    if (blockX3 < 200)
                    {
                        blockX3 = 200;
                    }

                    if (blockX4 < 200)
                    {
                        blockX4 = 200;
                    }
                    //flyttar blocken höger
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && blockY1 != 730)
                    {
                        blockX1 = blockX1 + 20;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && blockY1 == 730 && blockY2 != 730)
                    {
                        blockX2 = blockX2 + 20;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && blockY2 == 730 && blockY3 != 730)
                    {
                        blockX3 = blockX3 + 20;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && blockY3 == 730 && blockY4 != 730)
                    {
                        blockX4 = blockX4 + 20;
                    }
                    //gör att blocken inte går utanför
                    if (blockX1 > 840)
                    {
                        blockX1 = 840;
                    }

                    if (blockX2 > 840)
                    {
                        blockX2 = 840;
                    }

                    if (blockX3 > 840)
                    {
                        blockX3 = 840;
                    }

                    if (blockX4 > 840)
                    {
                        blockX4 = 840;
                    }
                    //rita ut blocken
                    Raylib.BeginDrawing();
                    Raylib.DrawRectangleRec(blocks[0].shape, blocks[0].color);
                    if (y1 == 730)
                    {
                       Raylib.DrawRectangleRec(blocks[1].shape, blocks[1].color); 
                       
                    }
                    if (y2 == 730)
                    {
                        Raylib.DrawRectangleRec(blocks[2].shape, blocks[2].color);
                    }

                    if (y3 == 730)
                    {
                        Raylib.DrawRectangleRec(blocks[3].shape, blocks[3].color);
                    }

                    Raylib.DrawRectangleRec(left, Color.DARKGRAY);
                    Raylib.DrawRectangleRec(right, Color.DARKGRAY);
                    Raylib.DrawRectangleRec(bottom, Color.DARKGRAY);
                    Raylib.DrawRectangle(900, 80, 150,150, Color.WHITE);
                    Raylib.DrawText("Next Block", 920, 100, 20, Color.BLACK);
                    Raylib.DrawRectangle(960, 150, 15,15, Color.BLUE);
                    Raylib.DrawRectangle(975, 150, 15,15, Color.BLUE);
                    Raylib.DrawRectangle(960, 165, 15,15, Color.BLUE);
                    Raylib.DrawRectangle(975, 165, 15,15, Color.BLUE);
                    Raylib.DrawLine(960,150,990,150, Color.BLACK);
                    Raylib.DrawLine(960,150,960,180, Color.BLACK);
                    Raylib.DrawLine(990,150,990,180, Color.BLACK);
                    Raylib.DrawLine(960,165,990,165, Color.BLACK);
                    Raylib.DrawLine(960,180,990,180, Color.BLACK);
                    Raylib.DrawLine(975,150,975,180, Color.BLACK);
                    Raylib.DrawText("Calamity: "+ calamity, 20, 160, 20, Color.BLACK); // jk jk
                    Raylib.DrawText("Score: 0 (trash lul)", 20, 100, 20, Color.BLACK); // jag vet att den går ut över spelfältet, stäm mig
                    Raylib.ClearBackground(Color.WHITE);
                    if (blockY1 == 730 && blockY2 == 730 && blockY3 == 730 && blockY4 == 730)
                    {
                        Raylib.DrawText("Helt otroligt!!!", 80, 460, 150, Color.BLACK);
                    }
                    Raylib.EndDrawing();
                }
            }
        }
    }
}