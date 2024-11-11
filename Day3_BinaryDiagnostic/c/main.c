#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

char* decTo12BitBinary(unsigned int n) {
	char* binary = malloc(sizeof(char) * 13);
	for (int i = 1; i <= 12; i++) {
		int k = n >> (12 - i);
		if (k & 1)
			binary[i - 1] = '1';
		else
			binary[i - 1] = '0';
	}
	binary[13] = '\0';

	return binary;
}

unsigned int get_progressive_match(FILE* f, const unsigned int lines, bool invert) {
	rewind(f);

	char** m;
	size_t m_count = 0;
	char** mnew;
	size_t mnew_count = 0;
	m = malloc(sizeof(char*) * lines);
	mnew = malloc(sizeof(char*) * lines);
	for (int i = 0; i < lines; i++) {
		m[i] = malloc(sizeof(char) * 13);
		mnew[i] = malloc(sizeof(char) * 13);
	}

	char line[14];

	// Initialize m with all the input
	unsigned int i = 0;
	while (fgets(line, 14, f) != NULL) {
		memcpy(m[i], line, sizeof(char) * 12);
		m[i][13] = '\0';
		m_count++;
		i++;
	}

	for (unsigned int bit_pos = 0; bit_pos < 12; bit_pos++) {
		// Get most common bit in the current position
		size_t count = 0;
		for (unsigned int i = 0; i < m_count; i++) {
			count += m[i][bit_pos] == '1' ? 1 : 0;
		}
		
		char common_bit = count >= (float)m_count / 2 ? 
			(invert ? '0' : '1') : (invert ? '1' : '0');
		
		// Populate mnew with inputs that contain the most common bit
		for (unsigned int i = 0; i < m_count; i++) {
			if (m[i][bit_pos] == common_bit) {
				strcpy(mnew[mnew_count], m[i]);
				mnew_count++;
			}
		}

		for (unsigned int i = 0; i < lines; i++)
			strcpy(m[i], mnew[i]);

		m_count = mnew_count;
		mnew_count = 0;

		if (m_count == 1)
			break;
	}

	for (unsigned int i = 0; i < m_count; i++) {
		printf("Match: %s\n", m[i]);
	}

	return strtol(m[0], NULL, 2);

		// char line[13];

		// char best[13];
		// unsigned int best_matches = 0;

		// unsigned int i = 0;
		// while (fgets(line, 13, f) != NULL) {
		// 	unsigned int matches = 0;
		// 	for (int j = 0; j < 12; j++) {
		// 		if (line[j] == common_bits[j])
		// 			matches++;
		// 		else
		// 			break;
		// 	}
		// 	if (matches > best_matches) {
		// 		strncpy(best, line, 13);
		// 		best_matches = matches;
		// 	}
		// 	i++;
		// }

		// printf("Best match: %s; Matches: %u\n", best, best_matches);

	// return strtol(best, NULL, 2);
}

int main() {
	unsigned int gamma = 0;
	FILE* input;
	input = fopen("../input", "r");

	if (input == NULL) {
		printf("File can't be opened\n");
		return 1;
	}

	printf("=== Step 1 ===\n");

	char common_bits[13];
	unsigned int count[12] = {0};
	unsigned int lines = 0;

	char line[14];
	while (fgets(line, 14, input) != NULL) {
		lines++;
		for (int i = 0; i < 12; i++) {
			if (line[i] == '1')
				count[i]++;
		}
	}

	printf("Lines: %u\n", lines);

	printf("Set bit count: ");
	for (int i = 0; i < 12; i++) {
		common_bits[i] = count[i] > lines / 2 ? '1' : '0';
		printf("%u ", count[i]);
	}
	printf("\n");
	common_bits[13] = '\0';
	printf("Gamma binary: %.12s\n", common_bits);

	unsigned int common_bits_uint = strtol(common_bits, NULL, 2); // Convert string binary representation to uint
	printf("Gamma: %u\n", common_bits_uint);

	// Because we store 12 bit value in the unsigned int (16 bit) -> this inversion will set higher bits
	// They will be discarded
	unsigned int common_bits_rev = ~common_bits_uint;

	common_bits_rev &= 0b111111111111; // Apply mask to discard all bits higher than 12

	printf("Epsilon: %u\n", common_bits_rev);

	printf("Power consumption = Gamma * Epsilon = %u\n", common_bits_uint * common_bits_rev);

	printf("\n=== Step 2 ===\n");

	unsigned int oxygen = get_progressive_match(input, lines, false);
	unsigned int co2 = get_progressive_match(input, lines, true);

	printf("Oxygen: %u\n", oxygen);
	printf("CO2: %u\n", co2);
	// printf("CO2: %u\n", b);
	printf("Oxygen * CO2: %u\n", oxygen * co2);

	return 0;
}
