#include "chrono.h"
#include <iostream>
#include <chrono>
#include <thread>

Chrono::Chrono()
{

}

void Chrono::wait(int i)
{
   auto start = std::chrono::high_resolution_clock::now();
    std::this_thread::sleep_for(std::chrono::microseconds(i));
    auto end = std::chrono::high_resolution_clock::now();
    std::chrono::duration<double, std::milli> elapsed = end-start;
    std::cout << "Waited " << elapsed.count() << " ms\n";
}

