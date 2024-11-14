#include <stdlib.h>
#include <stdio.h>
#include <string.h>

#define MAX_NUM_STR_LEN 300
#define uint unsigned int
#define uchar unsigned char

void getNumbers(FILE* input, uchar** nums, size_t* count) {
	*count = 0;
	// Read numbers line
	char line[MAX_NUM_STR_LEN];
	fgets(line, MAX_NUM_STR_LEN, input);

	// Count numbers
	for (size_t i = 0; i < MAX_NUM_STR_LEN; i++) {
		if (line[i] == ',')
			(*count)++;
	}
	(*count)++;

	// Get numbers
	*nums = malloc(sizeof(uchar) * *count);

	size_t num_idx = 0;
	char* token = strtok(line, ",");
	do {
		uchar num = strtoul(token, NULL, 10);
		(*nums)[num_idx] = num;
		num_idx++;

		token = strtok(NULL, ",");
	} while (token != NULL);

}

int main() {
	FILE* input = fopen("../input", "r");
	if (input == NULL) {
		printf("Couldn't read file.");
		return 1;
	}

	uchar* nums = NULL;
	size_t nums_count;
	getNumbers(input, &nums, &nums_count);

	printf("There are %zu numbers\n", nums_count);
	printf("Numbers: ");
	for (size_t i = 0; i < nums_count; i++)
		printf("%u ", nums[i]);
	printf("\n");

	

	
	return 0;
}