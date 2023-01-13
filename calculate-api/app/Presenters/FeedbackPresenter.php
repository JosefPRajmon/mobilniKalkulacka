<?php
declare(strict_types=1);

namespace App\Presenterss;

class FeedbackPresenter extends Nette\Application\UI\Presenter {
    public $fedbackApi;

    public function actionSave($title, $feedback) {
        $this->fedbackApi->save($title, $feedback);
        $this->redirect("this");
    }
}

?>