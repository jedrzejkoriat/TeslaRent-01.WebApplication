import { useTranslation } from 'react-i18next';

function Privacy() {
    const { t } = useTranslation();
    return (
        <div style={{ paddingTop: '100px', paddingBottom: '100px' }}>
            <div className="container text-start">
                <h1 className="text-start">{t('privacyPolicy')}</h1>
                <p className="mb-4">
                    {t('privacyIntro1')}
                </p>

                <p className="mb-4">
                    {t('privacyIntro2')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('cookiesTitle')}</h2>
                <p className="mb-4">
                    {t('cookiesDescription1')}
                </p>
                <p className="mb-4">
                    {t('cookiesDescription2')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('infoCollectedTitle')}</h2>
                <p className="mb-2">{t('infoCollectedDescription')}</p>
                <ul className="list-disc list-inside mb-4">
                    <li>{t('firstName')}</li>
                    <li>{t('lastName')}</li>
                    <li>{t('emailAddress')}</li>
                    <li>{t('phoneNumber')}</li>
                </ul>
                <p className="mb-4">
                    {t('infoCollectedDisclaimer')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('noPersonalDataProcessingTitle')}</h2>
                <p className="mb-4">
                    {t('noPersonalDataProcessingDescription')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('educationalUseOnlyTitle')}</h2>
                <p className="mb-4">
                    {t('educationalUseOnlyDescription')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('fictionalReservationsTitle')}</h2>
                <p className="mb-4">
                    {t('fictionalReservationsDescription')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('noPaymentsTitle')}</h2>
                <p className="mb-4">
                    {t('noPaymentsDescription')}
                </p>

                <h2 className="text-xl font-semibold mt-8 mb-2">{t('fictionalRentalLocationsTitle')}</h2>
                <p className="mb-4">
                    {t('fictionalRentalLocationsDescription')}
                </p>

                <p className="mt-6 italic text-sm text-gray-600">
                    {t('privacyNoticeDisclaimer')}
                </p>
            </div>
        </div>
    )
}

export default Privacy;