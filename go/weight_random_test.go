package main

import (
	"fmt"
	"testing"
)

func TestWeightedRandom1(t *testing.T) {
	for i := 0; i < 100; i++ {
		fmt.Println(WeightedRandom1([]float32{0.1, 0.3, 0.6}))
	}
}

func TestWeightedRandom2(t *testing.T) {
	for i := 0; i < 100; i++ {
		fmt.Println(WeightedRandom2([]float32{0.1, 0.3, 0.6}))
	}
}

func TestWeightedRandom3(t *testing.T) {
	for i := 0; i < 100; i++ {
		fmt.Println(WeightedRandom3([]float32{0.1, 0.3, 0.6}))
	}
}

func TestWeightedRandom4(t *testing.T) {
	for i := 0; i < 100; i++ {
		fmt.Println(WeightedRandom4([]float64{0.1, 0.3, 0.6}))
	}
}
