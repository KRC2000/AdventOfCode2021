#include <limits.h>
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
	FILE* inputFile = fopen("../input", "r");

	if (inputFile == NULL) {
		printf("File can't be opened\n");
		return 1;
	}

	uint count = 0;
	long prev = LONG_MAX;
	char line[10];
	while (fgets(line, 10, inputFile) != NULL) {
		long num = strtol(line, NULL, 10);
		if (num > prev)
			count++;
		prev = num;
	}

	printf("Part 1. Count is: %u\n", count); // Part 1: 1446

	count = 0;
	rewind(inputFile);
	fgets(line, 10, inputFile);
	long num1 = strtol(line, NULL, 10);
	fgets(line, 10, inputFile);
	long num2 = strtol(line, NULL, 10);
	fgets(line, 10, inputFile);
	long num3 = strtol(line, NULL, 10);
	prev = num1 + num2 + num3;
	while (fgets(line, 10, inputFile) != NULL) {
		num1 = num2;
		num2 = num3;
		num3 = strtol(line, NULL, 10);
		long curr = num1 + num2 + num3;
		if (curr > prev) count++;
		prev = curr;
	}

	printf("Part 2. Count is: %u", count); // Part 2: 1486

	return 0;
}
