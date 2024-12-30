#include <cstdio>
#include <fstream>
#include <iostream>
#include <limits>
#include <string>

int main(int argc, char *argv[]) {
  std::ifstream reader("../input");
  if (!reader) {
    std::cerr << "Could not open file\n";
    return 1;
  }

  uint count = 0;
  uint prev = std::numeric_limits<uint>::max();
  std::string s;
  while (std::getline(reader, s)) {
    u_long num = std::strtoul(s.c_str(), nullptr, 10);
    if (num > prev)
      count++;
    prev = num;
  }

  printf("Part 1. Count is: %u\n", count);

  reader.clear();
  reader.seekg(0);

  count = 0;
  std::getline(reader, s);
  uint num1 = std::strtoul(s.c_str(), nullptr, 10);
  std::getline(reader, s);
  uint num2 = std::strtoul(s.c_str(), nullptr, 10);
  std::getline(reader, s);
  uint num3 = std::strtoul(s.c_str(), nullptr, 10);
  prev = num1 + num2 + num3;

  while (std::getline(reader, s)) {
	num1 = num2;
	num2 = num3;
	num3 = std::strtoul(s.c_str(), nullptr, 10);
	uint sum = num1 + num2 + num3;
	if (sum > prev) count++;
	prev = sum;
  }

  printf("Part 2. Count is: %u\n", count);

  return 0;
}
