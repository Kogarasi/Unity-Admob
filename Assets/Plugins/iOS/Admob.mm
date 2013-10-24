#import <UIKit/UIKit.h>

extern "C" {
#import "GADBannerView.h"
}

extern UIViewController *UnityGetGLViewController();

@interface AdmobPlugin : NSObject
{
    GADBannerView *bannerView;
}
@end

@implementation AdmobPlugin

- (id)initWithAdmobId:(const char*)admob_id
{
    
    NSLog( @"Awake initWithAdmobId" );
    
    bannerView = [[GADBannerView alloc] initWithFrame:CGRectMake(
                                                                 0.0, UnityGetGLViewController().view.frame.size.height - GAD_SIZE_320x50.height, GAD_SIZE_320x50.width, GAD_SIZE_320x50.height )];
    
    bannerView.adUnitID = [NSString stringWithCString:admob_id encoding:NSASCIIStringEncoding];
    
    NSLog( @"Set View/Controller" );
    bannerView.rootViewController = UnityGetGLViewController();
    [UnityGetGLViewController().view addSubview:bannerView];
    
    NSLog( @"Load Request" );
    [bannerView loadRequest:[GADRequest request]];
    
    
    NSLog( @"End initWithAdmobId" );
    
    return self;
}

- (void)dealloc
{
    [bannerView release];
    [super dealloc];
}

- (void)setVisibility:(BOOL)visibility
{
    bannerView.hidden = visibility ? NO : YES;
}

@end

/*
 Unity用のインターフェース定義
 */

extern "C" {
    void *_AdmobPlugin_Init( const char *admob_id );
    void _AdmobPlugin_SetVisibility( void *instance, BOOL visibility );
}

void *_AdmobPlugin_Init( const char *admob_id ){
    id instance = [[AdmobPlugin alloc] initWithAdmobId:admob_id];
    return (void*)instance;
}

void _AdmobPlugin_SetVisibility( void *instance, BOOL visibility ){
    AdmobPlugin *admob = (AdmobPlugin*)instance;
    [admob setVisibility:visibility];
}