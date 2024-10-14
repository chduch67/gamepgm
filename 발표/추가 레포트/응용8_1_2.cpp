#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include <time.h>

void move_arrow_key(char chr, int *x, int *y, int x_b, int y_b);
void gotoxy(int x, int y);
void draw_check01(int c, int r);
void game_control(int c, int r, int time_limit);
void display_stone(int matrix[][20], int r, int stone_color, char stone_shape);
void change_stone_color(int color);
int get_color_code(char color_choice);

int main(void)
{
    int c, r, time_limit;

    printf("열 크기를 입력하세요 (2-20): ");
    scanf("%d", &c);
    printf("행 크기를 입력하세요 (2-20): ");
    scanf("%d", &r);
    printf("제한 시간을 입력하세요 (초): ");
    scanf("%d", &time_limit);
    system("cls");

    if (c < 2 || c > 20 || r < 2 || r > 20) {
        printf("유효하지 않은 크기입니다. 2와 20 사이의 값을 입력하세요.\n");
        return 1;
    }

    game_control(c, r, time_limit);
    return 0;
}

void gotoxy(int x, int y)
{
    COORD Pos = {x - 1, y - 1};
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), Pos);
}

void draw_check01(int c, int r)
{
    int i, j;
    unsigned char a = 0xa6;
    unsigned char b[12];
    for (i = 1; i < 12; i++)
        b[i] = 0xa0 + i;

    printf("%c%c", a, b[3]);
    for (i = 0; i < c - 1; i++)
        printf("%c%c", a, b[8]);
    printf("%c%c", a, b[4]);
    printf("\n");
    for (i = 0; i < r - 1; i++)
    {
        printf("%c%c", a, b[7]);
        for (j = 0; j < c - 1; j++)
            printf("%c%c", a, b[11]);
        printf("%c%c", a, b[9]);
        printf("\n");
    }
    printf("%c%c", a, b[6]);
    for (i = 0; i < c - 1; i++)
        printf("%c%c", a, b[10]);
    printf("%c%c", a, b[5]);
    printf("\n");
}

void game_control(int c, int r, int time_limit)
{
    int x = 1, y = 1, matrix[20][20] = {0};
    char key;
    int stone_color = 7;
    char stone_shape = '*';
    time_t start_time = time(NULL);

    do
    {
        
        time_t current_time = time(NULL);
        int elapsed_time = (int)(current_time - start_time);

        if (elapsed_time >= time_limit)
        {
            gotoxy(1, r + 6);
            printf("시간 종료! 게임을 종료합니다.\n");
            exit(0);
        }

        gotoxy(1, 1);
        draw_check01(c, r);
        display_stone(matrix, r, stone_color, stone_shape);
        gotoxy(x * 2, y);
        printf("○");
        gotoxy(1, r + 3);
        printf("방향키로 움직이고 스페이스 키를 누르시오. (ESC: 종료, Enter: 초기화, C: 색상 변경, S: 모양 변경)");

    
        gotoxy(1, r + 4);
        printf("남은 시간: %d초", time_limit - elapsed_time);

        key = getch();

        if (key == 27)
            exit(0);
        else if (key == 32)
        {
            int posX = x; 
            if (matrix[y][posX] == 1)
                matrix[y][posX] = 0;
            else
                matrix[y][posX] = 1;
        }
        else if (key == 13)
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    matrix[i][j] = 0;
            gotoxy(1, 1);
            draw_check01(c, r);
        }
        else if (key == 'c' || key == 'C')
        {
            char color_choice;
            gotoxy(1, r + 4);
            printf("색상을 선택하세요 (1: 빨강, 2: 초록, 3: 파랑): ");
            color_choice = getch();
            stone_color = get_color_code(color_choice);
            gotoxy(1, r + 4);
            printf("색상이 변경되었습니다.                          "); 
        }
        else if (key == 's' || key == 'S')
        {
            char shape_choice;
            gotoxy(1, r + 5);
            printf("모양을 선택하세요 (1: *, 2: ^, 3: #): ");
            shape_choice = getch();
            switch (shape_choice)
            {
                case '1': stone_shape = '*'; break; 
                case '2': stone_shape = '^'; break;
                case '3': stone_shape = '#'; break; 
                default: stone_shape = '*'; break; 
            }
            gotoxy(1, r + 5);
            printf("모양이 변경되었습니다.                          ");
        }
        else if (key >= 72)
            move_arrow_key(key, &x, &y, c - 1, r);

    } while (1);
}

void display_stone(int matrix[][20], int r, int stone_color, char stone_shape)
{
    int x, y;
    for (y = 1; y <= r; y++)
    {
        for (x = 1; x <= 20; x++)
        {
            if (matrix[y][x] == 1)
            {
                change_stone_color(stone_color);
                gotoxy(x * 2, y);
                printf("%c", stone_shape);
            }
        }
    }
    change_stone_color(7);
}

void change_stone_color(int color)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), color);
}

int get_color_code(char color_choice)
{
    switch (color_choice)
    {
        case '1': return 12;
        case '2': return 10;
        case '3': return 9;
        default: return 7;
    }
}

void move_arrow_key(char key, int *x1, int *y1, int x_b, int y_b)
{
    switch (key)
    {
    case 72:
        if (*y1 > 1) (*y1)--; 
        break;
    case 75:
        if (*x1 > 1) (*x1)--;            
        break;
    case 77:
        if (*x1 < x_b / 2 + 1) (*x1)++;              
        break;
    case 80:
        if (*y1 < y_b) (*y1)++;
        break;
    default:
        return;
    }
}

