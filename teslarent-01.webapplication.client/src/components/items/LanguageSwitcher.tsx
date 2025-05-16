import { useTranslation } from 'react-i18next';

const LanguageSwitcher = () => {
    const { i18n } = useTranslation();

    const changeLanguage = (lng: 'en' | 'pl') => {
        i18n.changeLanguage(lng);
    };

    return (
        <div>
            <button onClick={() => changeLanguage('en')}>🇬🇧 English</button>
            <button onClick={() => changeLanguage('pl')}>🇵🇱 Polski</button>
        </div>
    );
};

export default LanguageSwitcher;