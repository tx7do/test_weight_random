from alias_method import prepare_aliased_randomizer
from binary_search import prepare_binary_search
from hopscotch import prepare_hopscotch_selection


def test_binary_search_selection():
    generator = prepare_binary_search([1, 2, 3])
    print(f'binary search select: {generator()}')


def test_hopscotch_selection():
    generator = prepare_hopscotch_selection([1, 2, 3])
    print(f'hopscotch select: {generator()}')


def test_alias_method_selection():
    generator = prepare_aliased_randomizer([1, 2, 3])
    print(f'alias method select: {generator()}')


if __name__ == '__main__':
    test_binary_search_selection()
    test_hopscotch_selection()
    test_alias_method_selection()
