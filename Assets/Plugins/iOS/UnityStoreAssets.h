#import <Foundation/Foundation.h>
#import "IStoreAsssets.h"

@interface UnityStoreAssets : NSObject <IStoreAsssets> {
	int version;
	NSMutableArray* virtualCurrenciesArray;
	NSMutableArray* virtualGoodsArray;
	NSMutableArray* virtualCurrencyPacksArray;
	NSMutableArray* virtualCategoriesArray;
	NSMutableArray* nonConsumablesArray;
}

- (id)initWithStoreAssetsJSON:(NSString*)storeAssetsJSON andVersion:(int)oVersion;

@end